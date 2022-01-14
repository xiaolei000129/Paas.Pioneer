using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Paas.Pioneer.Admin.Core.Application.Contracts.Cache;
using Paas.Pioneer.Admin.Core.Application.Contracts.Cache.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Cache
{
    public class CacheService : ApplicationService, ICacheService
    {
        private readonly ILogger<CacheService> _logger;
        private readonly RedisAdminKeys _redisAdminKeys;
        private readonly AppConfig _appConfig;
        public CacheService(ILogger<CacheService> logger,
             RedisAdminKeys redisAdminKeys,
             IOptions<AppConfig> appConfig)
        {
            _logger = logger;
            _redisAdminKeys = redisAdminKeys;
            _appConfig = appConfig.Value;
        }

        /// <summary>
        /// 缓存列表
        /// </summary>
        /// <returns></returns>
        public ResponseOutput<List<object>> GetList()
        {
            var list = new List<object>();
            var redisAdminKeysType = _redisAdminKeys.GetType();
            var properties = redisAdminKeysType.GetProperties();
            foreach (var propertie in properties)
            {
                var descriptionAttribute = propertie.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

                string value = string.Format(propertie.GetGetMethod()?.Invoke(_redisAdminKeys, null)?.ToString() ?? "", "");
                if (_appConfig.Tenant)
                {
                    value = value.Replace($"{CurrentTenant.Id}:", "");
                }
                list.Add(new
                {
                    propertie.Name,
                    Value = value,
                    descriptionAttribute?.Description
                });
            }
            return ResponseOutput.Succees(list);
        }

        /// <summary>
        /// 清楚缓存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> ClearAsync(CacheDeleteInput model)
        {
            if (_appConfig.Tenant)
            {
                model.cacheKey = $"{CurrentTenant.Id}:{model.cacheKey}";
            }
            _logger.LogWarning($"{CurrentUser.Id}.{CurrentUser.Name}清除缓存[{model.cacheKey}]");
            await DelByPatternAsync(model.cacheKey);
            return ResponseOutput.Succees("操作成功");
        }

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private async Task<long> DelByPatternAsync(string pattern)
        {
            if (pattern.IsNull())
                return default;
            pattern = Regex.Replace(pattern, @"\{.*\}", "*");
            var keys = await RedisHelper.KeysAsync(pattern);
            if (keys != null && keys.Length > 0)
            {
                return await RedisHelper.DelAsync(keys);
            }
            return default;
        }
    }
}