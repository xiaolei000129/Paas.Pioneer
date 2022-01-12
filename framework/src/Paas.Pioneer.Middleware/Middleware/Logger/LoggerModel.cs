using System.Net;

namespace Paas.Pioneer.Middleware.Middleware.Logger
{
	/// <summary>
	/// 日志输出格式
	/// </summary>
	internal class LoggerModel
	{
		/// <summary>
		/// 连接Id
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// 请求地址
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// 请求方法
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// 令牌
		/// </summary>
		public string Token { get; set; }

		/// <summary>
		/// Query参数
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Body参数
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// 响应内容
		/// </summary>
		public string ResponseContent { get; set; }

		/// <summary>
		/// 状态码
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// 耗时
		/// </summary>
		public double TotalSeconds { get; set; }
	}
}
