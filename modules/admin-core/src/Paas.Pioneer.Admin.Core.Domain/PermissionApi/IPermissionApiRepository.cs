using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.PermissionApi
{
    public interface IPermissionApiRepository : IRepository<Ad_PermissionApiEntity, Guid>, IBaseExtensionRepository<Ad_PermissionApiEntity>
    {
        /// <summary>
        /// 通过PermissionId获取ApiIdList
        /// </summary>
        /// <param name="PermissionId"></param>
        /// <returns></returns>
        Task<IEnumerable<Guid>> GetApiIdListByPermissionIdAsync(Guid PermissionId);
    }
}
