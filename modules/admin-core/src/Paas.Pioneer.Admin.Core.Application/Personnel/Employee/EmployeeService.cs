using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Employee;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Organization;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Personnel.Employee
{
    /// <summary>
    /// 员工服务
    /// </summary>
    public class EmployeeService : ApplicationService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPositionRepository _positionRepository;

        public EmployeeService(
            IEmployeeRepository userRepository,
            IOrganizationRepository organizationRepository,
            IPositionRepository positionRepository
        )
        {
            _employeeRepository = userRepository;
            _organizationRepository = organizationRepository;
            _positionRepository = positionRepository;
        }

        public async Task<EmployeeGetOutput> GetAsync(Guid id)
        {
            var data = await _employeeRepository.GetAsync(
                expression: x => x.Id == id,
                selector: x => new EmployeeGetOutput()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Name = x.Name,
                    NickName = x.NickName,
                    Sex = x.Sex,
                    Code = x.Code,
                    OrganizationId = x.OrganizationId,
                    PositionId = x.PositionId,
                    Phone = x.Phone,
                    Email = x.Email,
                    EntryTime = x.EntryTime,
                });
            data.OrganizationName = await _organizationRepository.GetAsync(
                expression: x => x.Id == data.OrganizationId,
                selector: x => x.Name);

            data.PositionName = await _positionRepository.GetAsync(
                expression: x => x.Id == data.PositionId,
                selector: x => x.Name);

            return data;
        }

        public async Task<Page<EmployeeListOutput>> GetPageListAsync(PageInput<EmployeeDataOutput> input)
        {
            var pageList = await _employeeRepository.GetEmployeePageListAsync(input);
            return pageList;
        }

        public async Task AddAsync(EmployeeAddInput input)
        {
            var entity = ObjectMapper.Map<EmployeeAddInput, Pe_EmployeeEntity>(input);
            await _employeeRepository.InsertAsync(entity);
        }

        public async Task UpdateAsync(EmployeeUpdateInput input)
        {
            var employee = await _employeeRepository.GetAsync(input.Id);
            if (employee?.Id == Guid.Empty)
            {
                throw new BusinessException("用户不存在！");
            }

            ObjectMapper.Map(input, employee);
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(Guid id)
        {
            //删除员工
            await _employeeRepository.DeleteAsync(m => m.Id == id);
        }

        public async Task BatchSoftDeleteAsync(Guid[] ids)
        {
            await _employeeRepository.DeleteAsync(x => ids.Contains(x.Id));
        }
    }
}