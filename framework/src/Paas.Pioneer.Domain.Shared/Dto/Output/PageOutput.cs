using System.Collections.Generic;

namespace Paas.Pioneer.Domain.Shared.Dto.Output
{
	/// <summary>
	/// 分页信息输出
	/// </summary>
	public class PageOutput<T>
	{
		/// <summary>
		/// 是否成功标记
		/// </summary>
		public bool Success { get; private set; }

		/// <summary>
		/// 状态码
		/// </summary>
		public int Code => Success ? 1 : 0;

		/// <summary>
		/// 消息
		/// </summary>
		public string Msg { get; private set; }

		/// <summary>
		/// 数据
		/// </summary>
		public Page<T> Data { get; set; }

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		public PageOutput<T> Succees(Page<T> data = default)
		{
			Success = true;
			Data = data;
			Msg = "操作成功";
			return this;
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		/// <param name="msg">消息</param>
		public PageOutput<T> Succees(string msg = null, Page<T> data = default)
		{
			Success = true;
			Data = data;
			Msg = msg;
			return this;
		}


		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public PageOutput<T> Error(Page<T> data = default)
		{
			Success = false;
			Msg = "操作失败";
			Data = data;
			return this;
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="msg">消息</param>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public PageOutput<T> Error(string msg = null, Page<T> data = default)
		{
			Success = false;
			Msg = msg;
			Data = data;
			return this;
		}
	}

	public class Page<T>
	{

		/// <summary>
		/// 数据总数
		/// </summary>
		public long Total { get; set; } = 0;

		/// <summary>
		/// 数据
		/// </summary>
		public IEnumerable<T> List { get; set; }
	}

	/// <summary>
	/// 响应数据静态输出
	/// </summary>
	public static partial class PageOutput
	{
		/// <summary>
		/// 成功
		/// </summary>
		/// <returns></returns>
		public static PageOutput<T> Succees<T>()
		{
			return Succees<T>();
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static PageOutput<T> Succees<T>(Page<T> data = default)
		{
			return new PageOutput<T>().Succees(data);
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		/// <param name="msg">消息</param>
		/// <returns></returns>
		public static PageOutput<T> Succees<T>(string msg = null, Page<T> data = default)
		{
			return new PageOutput<T>().Succees(msg, data);
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <returns></returns>
		public static PageOutput<T> Error<T>()
		{
			return Error<T>();
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="msg">消息</param>
		/// <returns></returns>
		public static PageOutput<T> Error<T>(string msg = null)
		{
			return new PageOutput<T>().Error(msg);
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static PageOutput<T> Error<T>(Page<T> data = default)
		{
			return new PageOutput<T>().Error(data);
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="msg">消息</param>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static PageOutput<T> Error<T>(string msg = null, Page<T> data = default)
		{
			return new PageOutput<T>().Error(msg, data);
		}

		/// <summary>
		/// 根据布尔值返回结果
		/// </summary>
		/// <param name="success"></param>
		/// <returns></returns>
		public static PageOutput<T> Result<T>(bool success)
		{
			return success ? Succees<T>() : Error<T>();
		}
	}
}