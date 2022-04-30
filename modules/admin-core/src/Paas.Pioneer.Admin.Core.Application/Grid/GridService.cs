using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Grid;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Grid
{
    /// <summary>
    /// 栅格管理服务
    /// </summary>
     public class GridService : ApplicationService, IGridService
    {
        
        private readonly IGridRepository _gridRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public GridService(IGridRepository gridRepository)
        {
            _gridRepository = gridRepository;
        }

        /// <summary>
        /// 查询栅格管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<GetGridOutput> GetAsync(Guid id)
        {
            var result = await _gridRepository.GetAsync(p=>p.Id == id, x => new GetGridOutput()
            {
                DictionaryId = x.DictionaryId,
                GridType = x.GridType,
                Name = x.Name,
                Portrait = x.Portrait,
                Expand = x.Expand,
                Sort = x.Sort,
                Description = x.Description,
                LastModificationTime = x.LastModificationTime,
                CreationTime = x.CreationTime,
                Id = x.Id,
            });
            return result;
        }

        /// <summary>
        /// 查询分页栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<Page<GetGridPageListOutput>> GetPageListAsync(PageInput<GetGridPageListInput> input)
        {
            var data = await _gridRepository.GetResponseOutputPageListAsync(x => new GetGridPageListOutput
            {
                DictionaryId = x.DictionaryId,
                GridType = x.GridType,
                Name = x.Name,
                Portrait = x.Portrait,
                Expand = x.Expand,
                Sort = x.Sort,
                Description = x.Description,
                LastModificationTime = x.LastModificationTime,
                CreationTime = x.CreationTime,
                Id = x.Id,
            }, input: input);
            return data;
        }

        /// <summary>
        /// 新增栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task AddAsync(AddGridInput input)
        {
            var grid = ObjectMapper.Map<AddGridInput, Information_GridEntity>(input);
            await _gridRepository.InsertAsync(grid);
        }

        /// <summary>
        /// 修改栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateGridInput input)
        {
            var entity = await _gridRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                throw new BusinessException("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _gridRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除栅格管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _gridRepository.DeleteAsync(m => m.Id == id);
        }

        /// <summary>
        /// 批量删除栅格管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _gridRepository.DeleteAsync(x => ids.Contains(x.Id));
        }
    }
}