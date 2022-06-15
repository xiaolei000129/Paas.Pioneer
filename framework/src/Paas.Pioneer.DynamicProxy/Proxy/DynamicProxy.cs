using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.DynamicProxy
{
    public class DynamicProxy : DispatchProxy, IScopedDependency
    {
        private static ILogger<DynamicProxy>? _logger { get; set; }

        /// <summary>
        /// 目标类
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// 动作之后执行
        /// </summary>
        private Action<object?[]?> _afterAction { get; set; }

        /// <summary>
        /// 动作之前执行
        /// </summary>
        private Action<object?[]?, object> _beforeAction { get; set; }

        /// <summary>
        /// 目标方法异常(默认抛出异常信息)
        /// </summary>
        private Action<MethodInfo?, object?[]?, Exception> _methodExceptionAction { get; set; } = (methodInfo, args, ex) => throw ex;

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="targetMethod">目标方法</param>
        /// <param name="args">方法参数</param>
        /// <returns></returns>
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            // 异常信息
            Exception exception = null;
            // 方法执行前处理
            AfterAction(args);
            // 方法执行结果
            object resultValue = null;
            if (targetMethod != null)
            {
                try
                {
                    //调用实际目标对象的方法
                    resultValue = targetMethod.Invoke(Target, args);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Invoke=>调用实际目标对象的方法出现错误：{ex.Message}，{ex.StackTrace}");
                    _methodExceptionAction(targetMethod, args, ex);
                }
            }
            // 方法执行后处理
            BeforeAction(args, resultValue);

            // 判断主体方法执行是否异常
            if (exception != null)
            {
                throw exception;
            }

            return resultValue;
        }

        /// <summary>
        /// 创建代理实例
        /// </summary>
        /// <param name="target">代理的接口类型</param>
        /// <param name="afterAction">方法执行前执行的事件</param>
        /// <param name="beforeAction">方法执行后执行的事件</param>
        /// <returns></returns>
        public T Create<T>(T target,
            Action<object?[]?> afterAction,
            Action<object?[]?, object> beforeAction,
            Action<MethodInfo?, object?[]?, Exception> targetMethodExceptionAction,
            ILogger<DynamicProxy> logger)
        {
            // DispatchProxy.Create创建T对象
            object proxy = Create<T, DynamicProxy>();
            _logger = logger;
            DynamicProxy proxyDecorator = (DynamicProxy)proxy;
            proxyDecorator.Target = target;
            proxyDecorator._afterAction = afterAction;
            proxyDecorator._beforeAction = beforeAction;
            proxyDecorator._methodExceptionAction = targetMethodExceptionAction;
            return (T)proxy;
        }

        private void AfterAction(object?[]? args)
        {
            if (_afterAction == null)
            {
                return;
            }

            try
            {
                _afterAction.Invoke(args);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AfterAction=>执行之前异常：{ex.Message}，{ex.StackTrace}");
            }
        }

        private void BeforeAction(object?[]? args, object? result)
        {
            if (_beforeAction == null)
            {
                return;
            }

            try
            {
                _beforeAction.Invoke(args, result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BeforeAction=>执行之后异常：{ex.Message}，{ex.StackTrace}");
            }
        }
    }
}
