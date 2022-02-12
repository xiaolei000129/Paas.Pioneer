using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Paas.Pioneer.Knife4jUI.Swagger
{
    /// <summary>
    /// Swagger拓展方法
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// 添加swagger
        /// </summary>
        /// <param name="services">服务容器</param>
        /// <param name="title">标题</param>
        /// <param name="controllerString">控制器字符串</param>
        /// <param name="version">版本</param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, string title, string controllerString, string version = "1.0.0")
        {
            var documentFileNameList = GetXmlDocumentFileNameList();
            if (documentFileNameList == null && !documentFileNameList.Any())
                return services;

            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = version });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.AddServer(new OpenApiServer()
                {
                    Url = title,
                    Description = version
                });
                options.CustomOperationIds(apiDesc =>
                {
                    var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
                    return controllerAction.ControllerName + "-" + controllerAction.ActionName;
                });
                foreach (var documentFileName in documentFileNameList)
                {
                    options.IncludeXmlComments(documentFileName, documentFileName == controllerString);
                }
            });
        }

        /// <summary>
        /// 使用SwaggerUI
        /// </summary>
        /// <param name="app">应用</param>
        /// <param name="url">地址</param>
        /// <param name="description">描述</param>
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app, string url, string description)
        {
            app.UseSwagger();
            app.UseKnife4UI(c =>
            {
                c.RoutePrefix = ""; // serve the UI at root
                c.SwaggerEndpoint(url, description);
            });
            return app;
        }

        /// <summary>
        /// 映射SwaggerUI
        /// </summary>
        /// <param name="endpoints"></param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapSwaggerUI(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapSwagger("{documentName}/api-docs");
            return endpoints;
        }

        /// <summary>
        /// 获取所有程序xml文件
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetXmlDocumentFileNameList()
        {
            var documentFileNameList = new List<string>();
            var libTypeList = new List<string>() { "project", "package" };
            var fileNameList = DependencyContext.Default.CompileLibraries
                .Where(lib => libTypeList.Contains(lib.Type)
                && !lib.Name.StartsWith("Microsoft.", StringComparison.CurrentCultureIgnoreCase)
                && !lib.Name.StartsWith("System.", StringComparison.CurrentCultureIgnoreCase)
                && !lib.Name.StartsWith("runtime.", StringComparison.CurrentCultureIgnoreCase))
                .Select(lib => $"{lib.Name}.xml").ToList();

            foreach (var fileName in fileNameList)
            {
                string documentFileName = Path.Combine(AppContext.BaseDirectory, fileName);
                if (File.Exists(documentFileName))
                {
                    documentFileNameList.Add(documentFileName);
                }
            }
            return documentFileNameList;
        }
    }
}
