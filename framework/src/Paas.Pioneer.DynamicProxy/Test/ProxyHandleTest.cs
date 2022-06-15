using System;
using System.Reflection;
using System.Text.Json;

namespace Paas.Pioneer.DynamicProxy
{
    public class ProxyHandleTest : IProxyHandle
    {
        public void AfterAction(object[] args)
        {
            Console.WriteLine($"ProxyHandleTest=》AfterAction方法执行，args：{JsonSerializer.Serialize(args)}");
        }

        public void BeforeAction(object[] args, object resultValue)
        {
            Console.WriteLine($"ProxyHandleTest=》BeforeAction方法执行，args：{JsonSerializer.Serialize(args)}，result：{resultValue}");
        }

        public void MethodExceptionAction(MethodInfo targetMethod, object[] args, Exception ex)
        {
            Console.WriteLine($"ProxyHandleTest=》MethodExceptionAction方法执行，targetMethod,：{targetMethod.Name}，args：{JsonSerializer.Serialize(args)}，ex：{ex.Message}");
        }
    }
}
