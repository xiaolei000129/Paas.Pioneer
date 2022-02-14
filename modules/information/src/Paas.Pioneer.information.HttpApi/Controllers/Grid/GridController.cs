using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Grid;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Output;

namespace Paas.Pioneer.Information.HttpApi.Controllers.Grid
{
    /// <summary>
    /// Grid
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
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
        /// 查询Grid
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<GetGridOutput>> Get(Guid id)
        {
            return await _gridService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Page<GetGridPageListOutput>>> GetPageList(PageInput<GetGridPageListInput> input)
        {
            return await _gridService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] AddGridInput input)
        {
            return await _gridService.AddAsync(input);
        }

        /// <summary>
        /// 修改Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] UpdateGridInput input)
        {
            return await _gridService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除Grid
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> Delete(Guid id)
        {
            return await _gridService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除Grid
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _gridService.BatchSoftDeleteAsync(ids);
        }
    }
}