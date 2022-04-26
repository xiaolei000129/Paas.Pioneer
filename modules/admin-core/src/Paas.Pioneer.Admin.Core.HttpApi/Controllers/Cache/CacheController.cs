using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Cache;
using Paas.Pioneer.Admin.Core.Application.Contracts.Cache.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 接口管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class CacheController : AbpControllerBase
    {
        private readonly ICacheService _cacheService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cacheService"></param>
        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        /// <summary>
        /// 获取缓存列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseOutput<List<object>> List()
        {
            return _cacheService.GetList();
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> Clear(CacheDeleteInput model)
        {
            return await _cacheService.ClearAsync(model);
        }
    }
}
