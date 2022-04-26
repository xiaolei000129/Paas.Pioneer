using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee
{
    /// <summary>
    /// 员工服务
    /// </summary>
    public interface IEmployeeService
    {
        Task<EmployeeGetOutput> GetAsync(Guid id);

        Task<Page<EmployeeListOutput>> GetPageListAsync(PageInput<EmployeeDataOutput> input);

        Task AddAsync(EmployeeAddInput input);

        Task UpdateAsync(EmployeeUpdateInput input);

        Task DeleteAsync(Guid id);

        Task BatchSoftDeleteAsync(Guid[] ids);
    }
}