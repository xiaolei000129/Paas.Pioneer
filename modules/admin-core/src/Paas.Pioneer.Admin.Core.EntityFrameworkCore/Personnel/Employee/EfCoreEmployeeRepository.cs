using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Employee;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Organization;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Personnel.Employee
{
    public class EfCoreEmployeeRepository : BaseExtensionsRepository<Pe_EmployeeEntity>, IEmployeeRepository
    {
        private readonly IRepository<Pe_OrganizationEntity, Guid> _organizationRepository;
        private readonly IRepository<Pe_PositionEntity, Guid> _positionRepository;
        public EfCoreEmployeeRepository(IDbContextProvider<AdminsDbContext> dbContextProvider,
            IRepository<Pe_OrganizationEntity, Guid> organizationRepository,
            IRepository<Pe_PositionEntity, Guid> positionRepository)
            : base(dbContextProvider)
        {
            _organizationRepository = organizationRepository;
            _positionRepository = positionRepository;
        }

        public async Task<Page<EmployeeListOutput>> GetEmployeePageListAsync(PageInput<EmployeeDataOutput> input)
        {
            var employeeQueryable = (await GetQueryableAsync()).WhereDynamicFilter(input.DynamicFilter)
            .AsNoTracking();
            var organizationQueryable = await _organizationRepository.GetQueryableAsync();
            var positionQueryable = await _positionRepository.GetQueryableAsync();

            var employeeList = await employeeQueryable.OrderByDescending(x => x.CreationTime)
                .Page(input.CurrentPage, input.PageSize)
                .Select(x => new EmployeeListOutput()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NickName = x.NickName,
                    Phone = x.Phone,
                    PositionId = x.PositionId,
                    OrganizationId = x.OrganizationId
                }).ToListAsync();

            var OrganizationList = await organizationQueryable
                .Where(x => employeeList.Select(p => p.OrganizationId).Contains(x.Id))
                .Select(x => new Pe_OrganizationEntity(x.Id)
                {
                    Name = x.Name,
                })
                .ToListAsync();

            var PositionList = await positionQueryable
                .Where(x => employeeList.Select(p => p.PositionId).Contains(x.Id))
                .Select(x => new Pe_PositionEntity(x.Id)
                {
                    Name = x.Name,
                })
                .ToListAsync();

            foreach (var item in employeeList)
            {
                item.PositionName = PositionList.Where(x => x.Id == item.PositionId).Select(x => x.Name).FirstOrDefault();
                item.OrganizationName = OrganizationList.Where(x => x.Id == item.OrganizationId).Select(x => x.Name).FirstOrDefault();
            }

            var pageList = new Page<EmployeeListOutput>()
            {
                List = employeeList,
                Total = await employeeQueryable.CountAsync()
            };
            return pageList;
        }
    }
}
