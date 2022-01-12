using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Organization;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Personnel.Organization
{
    public class OrganizationService : ApplicationService, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<ResponseOutput<OrganizationGetOutput>> GetAsync(Guid id)
        {
            var result = await _organizationRepository.GetAsync(
                expression: x => x.Id == id,
                selector: x => new OrganizationGetOutput
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Name = x.Name,
                    Code = x.Code,
                    Value = x.Value,
                    PrimaryUserId = x.PrimaryEmployeeId,
                    EmployeeCount = x.EmployeeCount,
                    Enabled = x.Enabled,
                    Description = x.Description
                });
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<List<OrganizationListOutput>>> GetListAsync(string key)
        {

            Expression<Func<Pe_OrganizationEntity, bool>> predicate = x => true;

            if (key.NotNull())
            {
                predicate = predicate.And(a => a.Name.Contains(key) || a.Code.Contains(key));
            }

            var data = await _organizationRepository.GetResponseOutputListAsync(
                expression: predicate,
                selector: x => new OrganizationListOutput
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Name = x.Name,
                    Code = x.Code,
                    Value = x.Value,
                    Description = x.Description,
                    Enabled = x.Enabled,
                    CreatedTime = x.CreationTime,
                }, x => x.OrderBy(p => p.Sort));

            return data;
        }

        public async Task<IResponseOutput> AddAsync(OrganizationAddInput input)
        {
            var dictionary = ObjectMapper.Map<OrganizationAddInput, Pe_OrganizationEntity>(input);
            await _organizationRepository.InsertAsync(dictionary);
            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> UpdateAsync(OrganizationUpdateInput input)
        {
            var entity = await _organizationRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                return ResponseOutput.Error("数据字典不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _organizationRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _organizationRepository.DeleteAsync(a => a.Id == id);
            return ResponseOutput.Succees("删除成功！");
        }

    }
}