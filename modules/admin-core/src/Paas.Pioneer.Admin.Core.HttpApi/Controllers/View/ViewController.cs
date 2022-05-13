using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.View;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 视图管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class ViewController : AbpControllerBase
    {
        #region 构造函数

        private readonly IViewService _viewService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="viewService"></param>
        public ViewController(IViewService viewService)
        {
            _viewService = viewService;
        }

        #endregion

        #region 查询单条视图

        /// <summary>
        /// 查询单条视图
        /// </summary>
        /// <param name="id">视图ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ViewGetOutput> Get(Guid id)
        {
            return await _viewService.GetAsync(id);
        }

        #endregion

        #region 查询全部视图

        /// <summary>
        /// 查询全部视图
        /// </summary>
        /// <param name="key">视图路径,视图名称</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ViewGetOutput>> GetList(string key)
        {
            return await _viewService.GetListAsync(key);
        }
        #endregion

        #region 查询分页视图

        /// <summary>
        /// 查询分页视图(未使用)
        /// </summary>
        /// <param name="model">分页模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Page<ViewGetOutput>> GetPageList([FromBody] PageInput<ViewModel> model)
        {
            return await _viewService.GetPageListAsync(model);
        }

        #endregion

        #region 新增视图
        /// <summary>
        /// 新增视图
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] ViewAddInput input)
        {
            await _viewService.AddAsync(input);
        }
        #endregion

        #region 修改视图

        /// <summary>
        /// 修改视图
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] ViewUpdateInput input)
        {
            await _viewService.UpdateAsync(input);
        }
        #endregion

        #region 删除视图

        /// <summary>
        /// 删除视图
        /// </summary>
        /// <param name="id">视图ID</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDelete(Guid id)
        {
            await _viewService.DeleteAsync(id);
        }

        #endregion

        #region 批量删除视图
        /// <summary>
        /// 批量删除视图
        /// </summary>
        /// <param name="ids">集合ID</param>
        /// <returns></returns>
        [HttpPut]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _viewService.BatchSoftDeleteAsync(ids);
        }
        #endregion
    }
}