using Paas.Pioneer.Admin.Core.HttpApi.Client.ServiceProxies;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Admin.Core.HttpApi.Client.ConsoleTestApp
{
    public class ClientDemoService : ITransientDependency
    {
        private readonly IDictionaryServiceProxy _dictionaryServiceProxy;
        public ClientDemoService(IDictionaryServiceProxy dictionaryServiceProxy)
        {
            _dictionaryServiceProxy = dictionaryServiceProxy;
        }

        public async Task RunAsync()
        {
            try
            {
                await _dictionaryServiceProxy.GetListAsync(new Guid[] { Guid.NewGuid() });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}