using Microsoft.Extensions.Options;
using Paas.Pioneer.Domain.Shared.Configs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey
{
    /// <summary>
    /// 新闻常量
    /// </summary>
    public class RedisArticleKeys : ISingletonDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly AppConfig _appConfig;

        public RedisArticleKeys(ICurrentTenant currentTenant,
            IOptions<AppConfig> appConfig)
        {
            _currentTenant = currentTenant;
            _appConfig = appConfig.Value;
        }

        /// <summary>
        /// 根目录
        /// </summary>
        private string article()
        {
            if (_appConfig.Tenant)
            {
                return $"{_currentTenant.Id}:Article";
            }
            return "Article";
        }

        /// <summary>
        /// ArticleSlideshow
        /// </summary>
        public string Slideshow => $"{article}:Slideshow:";

        /// <summary>
        /// ArticleType
        /// </summary>
        public string Type => $"{article}:Type";

        /// <summary>
        /// ArticleArticle
        /// </summary>
        public string Articles => $"{article}:Article:";
    }
}
