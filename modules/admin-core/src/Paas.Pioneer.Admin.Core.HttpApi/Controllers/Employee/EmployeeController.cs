using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 员工管理
    /// </summary>
    [Route("api/personnel/[controller]/[action]")]
    [Authorize]
    public class EmployeeController : AbpControllerBase
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// 查询单条员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<EmployeeGetOutput>> Get(Guid id)
        {
            return await _employeeService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页员工
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        //[ResponseCache(Duration = 60)]
        public async Task<ResponseOutput<Page<EmployeeListOutput>>> GetPageList(PageInput<EmployeeDataOutput> input)
        {
            return await _employeeService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增员工
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] EmployeeAddInput input)
        {
            return await _employeeService.AddAsync(input);
        }

        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] EmployeeUpdateInput input)
        {
            return await _employeeService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> SoftDelete(Guid id)
        {
            return await _employeeService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除员工
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _employeeService.BatchSoftDeleteAsync(ids);
        }
    }
}