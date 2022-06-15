using System;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.DynamicProxy
{
    public interface ITestService
    {
        /// <summary>
        /// 获取用户Id信息
        /// </summary>
        /// <returns></returns>
        int GetUserId();

        void SetUserId(int userId);
    }

    [ProxyHandle(typeof(ProxyHandleTest))]
    public class TestService : ITestService, IScopedDependency
    {
        public int GetUserId()
        {
            Console.WriteLine($"执行TestService=>GetUserId()");
            return 10;
        }

        public void SetUserId(int userId)
        {
            Console.WriteLine($"执行TestService=>SetUserId({userId})");
            throw new Exception("执行TestService=>SetUserId测试异常");
        }
    }
}
