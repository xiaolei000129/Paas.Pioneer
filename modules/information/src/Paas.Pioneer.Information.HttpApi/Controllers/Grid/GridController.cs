using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Grid;

namespace Paas.Pioneer.Information.HttpApi.Controllers.Grid
{
    /// <summary>
    /// 栅格管理
    /// </summary>
    [Route("api/info/[controller]/[action]")]
    [Authorize]
    public class GridController : AbpController
    {

        private readonly IGridService _gridService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public GridController(IGridService gridService)
        {
            _gridService = gridService;
        }

        /// <summary>
        /// 查询栅格管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetGridOutput> Get(Guid id)
        {
            return await _gridService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Page<GetGridPageListOutput>> GetPageList([FromBody] PageInput<GetGridPageListInput> input)
        {
            return await _gridService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] AddGridInput input)
        {
            await _gridService.AddAsync(input);
        }

        /// <summary>
        /// 修改栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] UpdateGridInput input)
        {
            await _gridService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除栅格管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDelete(Guid id)
        {
            await _gridService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除栅格管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _gridService.BatchSoftDeleteAsync(ids);
        }
    }
}