using System;

namespace Paas.Pioneer.Domain.Shared.Dto.Output
{
	/// <summary>
	/// 响应数据静态输出
	/// </summary>
	[Serializable]
	public static class ResponseOutput
	{
		/// <summary>
		/// 成功
		/// </summary>
		/// <returns></returns>
		public static ResponseOutput<bool> Succees()
		{
			return Succees<bool>();
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <returns></returns>
		public static ResponseOutput<T> Succees<T>()
		{
			return Succees<T>();
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="msg">消息</param>
		/// <returns></returns>
		public static ResponseOutput<string> Succees(string msg = null)
		{
			return new ResponseOutput<string>().Succees(msg);
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static ResponseOutput<T> Succees<T>(T data = default)
		{
			return new ResponseOutput<T>().Succees(data);
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		/// <param name="msg">消息</param>
		/// <returns></returns>
		public static ResponseOutput<T> Succees<T>(string msg = null, T data = default)
		{
			return new ResponseOutput<T>().Succees(msg, data);
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <returns></returns>
		public static ResponseOutput<T> Error<T>()
		{
			return Error<T>();
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="msg">消息</param>
		/// <returns></returns>
		public static ResponseOutput<T> Error<T>(string msg = null)
		{
			return new ResponseOutput<T>().Error(msg);
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static ResponseOutput<T> Error<T>(T data = default)
		{
			return new ResponseOutput<T>().Error(data);
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="msg">消息</param>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static ResponseOutput<T> Error<T>(string msg = null, T data = default)
		{
			return new ResponseOutput<T>().Error(msg, data);
		}

		/// <summary>
		/// 根据布尔值返回结果
		/// </summary>
		/// <param name="success"></param>
		/// <returns></returns>
		public static ResponseOutput<T> Result<T>(bool success)
		{
			return success ? Succees<T>() : Error<T>();
		}
	}

	/// <summary>
	/// 响应数据输出
	/// </summary>
	[Serializable]
	public class ResponseOutput<T> : IResponseOutput<T>
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
		public T Data { get; private set; }

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		public ResponseOutput<T> Succees(T data = default)
		{
			Success = true;
			Data = data;
			Msg = "操作成功";
			return this;
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="msg">消息</param>
		public ResponseOutput<T> Succees(string msg = null)
		{
			Success = true;
			Msg = msg;
			return this;
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="data">数据</param>
		/// <param name="msg">消息</param>
		public ResponseOutput<T> Succees(string msg = null, T data = default)
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
		public ResponseOutput<T> Error(T data = default)
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
		/// <returns></returns>
		public ResponseOutput<T> Error(string msg = null)
		{
			Success = false;
			Msg = msg;
			return this;
		}

		/// <summary>
		/// 失败
		/// </summary>
		/// <param name="msg">消息</param>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public ResponseOutput<T> Error(string msg = null, T data = default)
		{
			Success = false;
			Msg = msg;
			Data = data;
			return this;
		}
	}
}