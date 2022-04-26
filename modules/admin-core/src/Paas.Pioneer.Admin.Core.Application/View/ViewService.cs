using Paas.Pioneer.Admin.Core.Application.Contracts.View;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.View;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.View
{
    public class ViewService : ApplicationService, IViewService
    {
        private readonly IViewRepository _viewRepository;

        public ViewService(IViewRepository viewRepository)
        {
            _viewRepository = viewRepository;
        }

        #region 查询单条视图

        /// <summary>
        /// 查询单条视图
        /// </summary>
        /// <param name="id">视图ID</param>
        /// <returns></returns>
        public async Task<ResponseOutput<ViewGetOutput>> GetAsync(Guid id)
        {
            var model = await _viewRepository.GetAsync(expression: x => x.Id == id, selector: x => new ViewGetOutput()
            {
                Id = x.Id,
                Description = x.Description,
                Enabled = x.Enabled,
                Label = x.Label,
                Name = x.Name,
                ParentId = x.ParentId,
                Path = x.Path,
            });
            return ResponseOutput.Succees(model);
        }

        #endregion

        #region 查询全部视图

        /// <summary>
        /// 查询全部视图
        /// </summary>
        /// <param name="key">视图路径,视图名称</param>
        /// <returns></returns>
        public async Task<ResponseOutput<List<ViewGetOutput>>> GetListAsync(string key)
        {
            Expression<Func<Ad_ViewEntity, bool>> expression = x => true;
            if (!key.IsNullOrEmpty())
            {
                expression = a => a.Path.Contains(key) || a.Label.Contains(key);
            }
            return await _viewRepository.GetResponseOutputListAsync(expression: expression, selector: x => new ViewGetOutput()
            {
                Id = x.Id,
                Description = x.Description,
                Enabled = x.Enabled,
                Label = x.Label,
                Name = x.Name,
                ParentId = x.ParentId,
                Path = x.Path,
                Cache = x.Cache,
                Sort = x.Sort,
            });
        }

        #endregion

        #region 查询分页视图

        /// <summary>
        /// 查询分页视图
        /// </summary>
        /// <param name="input">分页模型</param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<ViewGetOutput>>> GetPageListAsync(PageInput<ViewModel> input)
        {
            return await _viewRepository.GetResponseOutputPageListAsync(
                selector: x => new ViewGetOutput()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Enabled = x.Enabled,
                    Label = x.Label,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    Path = x.Path,
                    Cache = x.Cache,
                    Sort = x.Sort,
                },
                order: x => x.OrderByDescending(p => p.CreationTime),
                input);
        }
        #endregion

        #region 新增视图

        /// <summary>
        /// 新增视图
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> AddAsync(ViewAddInput input)
        {
            var entity = ObjectMapper.Map<ViewAddInput, Ad_ViewEntity>(input);
            await _viewRepository.InsertAsync(entity);
            return ResponseOutput.Succees("添加成功！");
        }

        #endregion

        #region 修改视图

        /// <summary>
        /// 修改视图
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateAsync(ViewUpdateInput input)
        {
            var entity = await _viewRepository.FindAsync(input.Id);
            if (!(entity?.Id != Guid.Empty))
            {
                throw new BusinessException("视图不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _viewRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        #endregion

        #region 删除视图
        /// <summary>
        /// 删除视图
        /// </summary>
        /// <param name="id">视图ID</param>
        /// <returns></returns>
        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _viewRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees("删除成功！");
        }
        #endregion

        #region 批量删除视图
        /// <summary>
        /// 批量删除视图
        /// </summary>
        /// <param name="ids">集合ID</param>
        /// <returns></returns>
        public async Task<IResponseOutput> BatchSoftDeleteAsync(Guid[] ids)
        {
            await _viewRepository.DeleteAsync(a => ids.Contains(a.Id));
            return ResponseOutput.Succees("删除成功！");
        }
        #endregion
    }
}