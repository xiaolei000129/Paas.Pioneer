using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared;
using Paas.Pioneer.Domain.Shared.Auth;
using Paas.Pioneer.DynamicProxy;
using Paas.Pioneer.Knife4jUI.Swagger;
using Paas.Pioneer.Middleware.Middleware.Extensions;
using Paas.Pioneer.Redis;
using System;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(Knife4jUISwaggerModule),
        typeof(DomainSharedModule),
        typeof(RedisModule),
        typeof(DynamicProxyModule)
        )]
    public class PioneerModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Allow";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            var configuration = context.Services.GetConfiguration();

            // 添加SignalR服务，Redis当底版
            context.Services.AddSignalR()
                .AddStackExchangeRedis(configuration["ConnectionStrings:Redis"]);

            ConfigureAuthentication(context, configuration);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

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
                            (path.StartsWithSegments("/chat-hub")))
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
