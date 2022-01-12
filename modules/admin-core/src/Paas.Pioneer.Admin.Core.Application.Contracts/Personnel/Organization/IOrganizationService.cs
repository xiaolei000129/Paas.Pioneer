using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization
{
    public partial interface IOrganizationService
    {
        Task<ResponseOutput<OrganizationGetOutput>> GetAsync(Guid id);

        Task<ResponseOutput<List<OrganizationListOutput>>> GetListAsync(string key);

        Task<IResponseOutput> AddAsync(OrganizationAddInput input);

        Task<IResponseOutput> UpdateAsync(OrganizationUpdateInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);
    }
}