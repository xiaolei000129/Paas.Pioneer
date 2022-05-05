using Lazy.SlideCaptcha.Core.Resources;
using Lazy.SlideCaptcha.Core.Resources.Handler;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Paas.Pioneer.Admin.Core.Application;
using Paas.Pioneer.Admin.Core.Domain.Shared.MultiTenancy;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Auth;
using Paas.Pioneer.Knife4jUI.Swagger;
using Paas.Pioneer.Middleware.Middleware.Extensions;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating.Scriban;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.Admin.Core.HttpApi.Host
{
    [DependsOn(
        typeof(AdminsHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AdminsApplicationModule),
        typeof(AdminsEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(Knife4jUISwaggerModule),
        typeof(AbpTextTemplatingScribanModule),
        typeof(DomainSharedModule)
    )]
    public class AdminsHttpApiHostModule : AbpModule
    {
        private IConfiguration Configuration;
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = Configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            ConfigureUrls(configuration);

            ConfigureCors(context, configuration);

            ConfigureAuthentication(context, configuration);

            // 业务错误拓展配置
            Configure<AbpExceptionHandlingOptions>(options =>
            {
                options.SendExceptionsDetailsToClients = true;
            });

            TextTemplatingScriban();

            context.Services.AddSlideCaptcha(configuration, options =>
            {
                for (int i = 1; i < 11; i++)
                {
                    options.Backgrounds.Add(new Resource(FileResourceHandler.TYPE, @$"wwwroot/captcha/images/background/{i}.jpg"));
                }
            });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
               {
                   builder
                       .WithOrigins(
                           configuration["App:CorsOrigins"]
                               .Split(",", StringSplitOptions.RemoveEmptyEntries)
                               .Select(o => o.RemovePostFix("/"))
                               .ToArray()
                       )
                       .WithAbpExposedHeaders()
                       .SetIsOriginAllowedToAllowWildcardSubdomains()
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
               });
            });
        }

        private void TextTemplatingScriban()
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AdminsHttpApiHostModule>("Paas.Pioneer.Admin.Core.HttpApi.Host");
            });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }


        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // ElasticApm
            //app.UseAllElasticApm(Configuration);

            // 判断是否测试模式
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 生成全局唯一Id
            app.UseCorrelationId();

            //路由
            app.UseRouting();

            // 格式化
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
            {
                ShowIsErrorFlagForSuccessfulResponse = true,
                ExcludePaths = new AutoWrapperExcludePath[] {
                    // 严格匹配
                    new AutoWrapperExcludePath("/v1/api-docs", ExcludeMode.StartWith),
                }
            });

            //全局日志中间件
            app.UseLoggerMiddleware();

            //跨域
            app.UseCors();

            // 验证
            app.UseAuthentication();

            // Jwt
            app.UseJwtTokenMiddleware();

            // 多租户
            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            // 工作单元
            app.UseUnitOfWork();

            // 授权
            app.UseAuthorization();

            // 配置末端点
            app.UseConfiguredEndpoints(endpoints =>
            {
                endpoints.MapSwaggerUI();
            });
        }

        /// <summary>
		/// 配置验证模式
		/// </summary>
		/// <param name="context"></param>
		/// <param name="configuration"></param>
		private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = nameof(ResponseAuthenticationHandler); //401
                options.DefaultForbidScheme = nameof(ResponseAuthenticationHandler);    //403
            })
            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            path.StartsWithSegments("/chat-hub"))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                            context.HttpContext.Request.Headers["Authorization"] = "Bearer " + accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["jwtconfig:issuer"],
                    ValidAudience = configuration["jwtconfig:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtconfig:securitykey"])),
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true
                };
            })
            .AddScheme<AuthenticationSchemeOptions, ResponseAuthenticationHandler>(nameof(ResponseAuthenticationHandler), o => { });
        }
    }
}
