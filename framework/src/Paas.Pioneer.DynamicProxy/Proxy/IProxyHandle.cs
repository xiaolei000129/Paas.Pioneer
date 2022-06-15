using System;
using System.Reflection;

namespace Paas.Pioneer.DynamicProxy
{
    public interface IProxyHandle
    {
        /// <summary>
        /// 执行之前
        /// </summary>
        /// <param name="args">目标方法参数</param>
        void AfterAction(object?[]? args);

        /// <summary>
        /// 执行之后
        /// </summary>
        /// <param name="args">目标方法参数</param>
        /// <param name="result">目标方法执行结果</param>
        void BeforeAction(object?[]? args, object resultValue);

        /// <summary>
        /// 方法执行错误处理
        /// </summary>
        /// <param name="targetMethod">目标方法</param>
        /// <param name="args">目标方法参数</param>
        /// <param name="ex">目标方法执行结果</param>
        void MethodExceptionAction(MethodInfo? targetMethod, object?[]? args, Exception ex);
    }
}
