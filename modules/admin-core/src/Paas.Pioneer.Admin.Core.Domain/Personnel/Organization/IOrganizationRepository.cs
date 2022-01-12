using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Personnel.Organization
{
    public interface IOrganizationRepository : IRepository<Pe_OrganizationEntity, Guid>, IBaseExtensionRepository<Pe_OrganizationEntity>
    {

    }
}
