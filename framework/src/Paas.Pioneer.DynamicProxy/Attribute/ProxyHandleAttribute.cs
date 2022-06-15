using System;

namespace Paas.Pioneer.DynamicProxy
{
    /// <summary>
    /// 代理Aop特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ProxyHandleAttribute : Attribute
    {
        public Type Type { get; set; }
        public ProxyHandleAttribute(Type type)
        {
            this.Type = type;
        }
    }
}
