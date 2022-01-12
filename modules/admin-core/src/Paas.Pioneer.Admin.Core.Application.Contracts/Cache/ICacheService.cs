using Paas.Pioneer.Admin.Core.Application.Contracts.Cache.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Cache
{
    /// <summary>
    /// 缓存服务
    /// </summary>
    public interface ICacheService : IApplicationService
    {
        /// <summary>
        /// 缓存列表
        /// </summary>
        /// <returns></returns>
        ResponseOutput<List<object>> GetList();

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <returns></returns>
        Task<IResponseOutput> ClearAsync(CacheDeleteInput model);
    }
}