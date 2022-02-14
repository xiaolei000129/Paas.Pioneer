using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Grid;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Information.Domain.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Information.Application.Grid
{
    /// <summary>
    /// Grid服务
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
        /// 查询Grid
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<ResponseOutput<GetGridOutput>> GetAsync(Guid id)
        {
            var result = await _gridRepository.GetAsync(p => p.Id == id, x => new GetGridOutput()
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
            return ResponseOutput.Succees(result);
        }

        /// <summary>
        /// 查询分页Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<GetGridPageListOutput>>> GetPageListAsync(PageInput<GetGridPageListInput> input)
        {
            return await _gridRepository.GetResponseOutputPageListAsync(selector: x => new GetGridPageListOutput
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
        }

        /// <summary>
        /// 新增Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> AddAsync(AddGridInput input)
        {
            var grid = ObjectMapper.Map<AddGridInput, Information_GridEntity>(input);
            await _gridRepository.InsertAsync(grid);
            return ResponseOutput.Succees("添加成功！");
        }

        /// <summary>
        /// 修改Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateAsync(UpdateGridInput input)
        {
            var entity = await _gridRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                return ResponseOutput.Error("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _gridRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        /// <summary>
        /// 删除Grid
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _gridRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees("删除成功！");
        }

        /// <summary>
        /// 批量删除Grid
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _gridRepository.DeleteAsync(x => ids.Contains(x.Id));
            return ResponseOutput.Succees("删除成功！");
        }
    }
}