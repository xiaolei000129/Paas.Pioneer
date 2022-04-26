using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Output;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization
{
    public partial interface IOrganizationService
    {
        Task<OrganizationGetOutput> GetAsync(Guid id);

        Task<List<OrganizationListOutput>> GetListAsync(string key);

        Task AddAsync(OrganizationAddInput input);

        Task UpdateAsync(OrganizationUpdateInput input);

        Task DeleteAsync(Guid id);
    }
}