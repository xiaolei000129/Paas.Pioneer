using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Domain.Personnel.Employee
{
    public interface IEmployeeRepository : IRepository<Pe_EmployeeEntity, Guid>, IBaseExtensionRepository<Pe_EmployeeEntity>
    {
        Task<Page<EmployeeListOutput>> GetEmployeePageListAsync(PageInput<EmployeeDataOutput> input);
    }
}
