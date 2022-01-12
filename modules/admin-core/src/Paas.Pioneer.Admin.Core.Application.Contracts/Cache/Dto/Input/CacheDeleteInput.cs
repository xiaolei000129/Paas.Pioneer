using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Cache.Dto.Input
{
    /// <summary>
    /// 缓存删除
    /// </summary>
    public class CacheDeleteInput
    {
        /// <summary>
        /// 删除
        /// </summary>
        public string cacheKey { get; set; }
    }
}
