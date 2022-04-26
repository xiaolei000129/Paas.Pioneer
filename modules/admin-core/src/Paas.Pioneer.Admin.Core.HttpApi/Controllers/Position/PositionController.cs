using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 职位管理
    /// </summary>
    [Route("api/personnel/[controller]/[action]")]
    [Authorize]
    public class PositionController : AbpControllerBase
    {
        private readonly IPositionService _positionService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="positionService"></param>
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        /// <summary>
        /// 查询单条职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<PositionDataOutput>> Get(Guid id)
        {
            return await _positionService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页职位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseOutput<Page<PositionListOutput>>> GetPageList([FromBody]PageInput<PositionDataOutput> model)
        {
            return await _positionService.GetPageListAsync(model);
        }

        /// <summary>
        /// 新增职位
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] PositionAddInput input)
        {
            return await _positionService.AddAsync(input);
        }

        /// <summary>
        /// 修改职位
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] PositionUpdateInput input)
        {
            return await _positionService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> SoftDelete(Guid id)
        {
            return await _positionService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除职位
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _positionService.BatchSoftDeleteAsync(ids);
        }
    }
}