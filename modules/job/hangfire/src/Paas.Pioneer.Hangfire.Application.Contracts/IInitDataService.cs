using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Hangfire.Application.Contracts
{
    /// <summary>
    /// 接口服务
    /// </summary>
    public interface IInitDataService : IApplicationService
    {
        Task<bool> EmptyDataAsync();

        Task<bool> GenerateDataAsync();

        Task<bool> WriteDataAsync();
    }
}