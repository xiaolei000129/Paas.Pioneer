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
		/// <param name="services"></param>
		/// <param name="title"></param>
		/// <param name="controllerString"></param>
		/// <param name="version"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwaggerGen(this IServiceCollection services, string title, string controllerString, string version = "1.0.0")
		{
			var tokenKey = "Authorization";
			var headers = new Dictionary<string, string>() { { tokenKey, "Bearer 用户登录凭证" } };
			return services.AddSwaggerGen(title, controllerString, version, headers);
		}

		private static IServiceCollection AddSwaggerGen(this IServiceCollection services, string title, string controllerString, string version = "1.0.0", Dictionary<string, string> headers = null)
		{
			List<string> documentFileNameList = GetXmlDocumentFileNameList();
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
				if (headers != null && headers.Any())
				{
					foreach (var header in headers)
					{
						options.AddSecurityDefinition(header.Value, new OpenApiSecurityScheme()
						{
							//jwt默认的参数名称
							Name = header.Key,
							//jwt默认存放Authorization信息的位置(请求头中)
							In = ParameterLocation.Header,
							Type = SecuritySchemeType.ApiKey,
							Description = "可直接在下框中输入Bearer {token}(注意中括号)"
						});
					}
				}
			});
		}

		/// <summary>
		/// 使用SwaggerUI
		/// </summary>
		/// <param name="app"></param>
		/// <param name="url"></param>
		/// <param name="description"></param>
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
		/// UI
		/// </summary>
		/// <param name="endpoints"></param>
		/// <returns></returns>
		public static IEndpointRouteBuilder MapSwaggerUI(this IEndpointRouteBuilder endpoints)
		{
			endpoints.MapSwagger("{documentName}/api-docs");
			return endpoints;
		}

		/// <summary>
		/// 获取文件名称
		/// </summary>
		/// <returns></returns>
		private static List<string> GetXmlDocumentFileNameList()
		{
			var documentFileNameList = new List<string>();
			try
			{
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
			}
			catch (Exception)
			{
				throw;
			}
			return documentFileNameList;
		}
	}
}
