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

        public RedisArticleKeys(ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }

        /// <summary>
        /// 根目录
        /// </summary>
        private string Article => $"{_currentTenant.Id}:Article";

        /// <summary>
        /// ArticleSlideshow
        /// </summary>
        public string Slideshow => $"{Article}:Slideshow:";

        /// <summary>
        /// ArticleType
        /// </summary>
        public string Type => $"{Article}:Type";

        /// <summary>
        /// ArticleArticle
        /// </summary>
        public string Articles => $"{Article}:Article:";
    }
}
