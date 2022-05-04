using System.Text.Json.Serialization;

namespace Paas.Pioneer.AutoWrapper
{
    /// <summary>
    /// 响应数据输出接口
    /// </summary>
    public interface IResponseOutput
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        bool Success { get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; }
    }

    /// <summary>
    /// 响应数据输出泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResponseOutput<T> : IResponseOutput
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        T Data { get; }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        ResponseOutput<T> Succees(T data);

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg">消息</param>
        ResponseOutput<T> Succees(string msg);

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        ResponseOutput<T> Succees(string msg, T data);


        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        ResponseOutput<T> Error(T data);

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        ResponseOutput<T> Error(string msg);

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        ResponseOutput<T> Error(string msg, T data);
    }
}