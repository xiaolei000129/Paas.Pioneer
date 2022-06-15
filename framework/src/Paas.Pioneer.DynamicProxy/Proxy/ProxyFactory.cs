using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.DynamicProxy
{
    /// <summary>
    /// 代理工厂
    /// </summary>
    public class ProxyFactory : IScopedDependency
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<IProxyHandle> _proxyHandleList;
        private readonly DynamicProxy _dynamicProxy;
        private readonly ILogger<DynamicProxy> _logger;
        public ProxyFactory(IEnumerable<IProxyHandle> proxyHandleList,
            IServiceProvider serviceProvider,
            DynamicProxy dynamicProxy,
            ILogger<DynamicProxy> logger)
        {
            this._serviceProvider = serviceProvider;
            this._proxyHandleList = proxyHandleList;
            this._dynamicProxy = dynamicProxy;
            this._logger = logger;
        }

        /// <summary>
        /// 创建代理实例
        /// </summary>
        /// <returns></returns>
        public T Create<T>() where T : class
        {

            var target = _serviceProvider.GetService<T>();
            if (target == null)
            {
                throw new BusinessException($"执行ProxyFactory=》Create方法：{typeof(T).FullName}未注入");
            }
            var type = target.GetType();
            var proxyHandleAttribute = type.GetCustomAttribute<ProxyHandleAttribute>();
            if (proxyHandleAttribute == null)
            {
                throw new BusinessException($"执行ProxyFactory=》Create方法：{type.FullName}需要添加ProxyHandleAttribute特性");
            }
            var proxyHandle = _proxyHandleList.FirstOrDefault(x => x.GetType() == proxyHandleAttribute.Type);
            if (proxyHandleAttribute == null)
            {
                throw new BusinessException($"执行ProxyFactory=》Create方法：没有找到对应IProxyHandle接口实现");
            }
            //创建代理类
            var proxy = _dynamicProxy.Create(target,
                proxyHandle.AfterAction,
                proxyHandle.BeforeAction,
                proxyHandle.MethodExceptionAction,
                _logger);
            return proxy;
        }
    }
}
