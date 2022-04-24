using Paas.Pioneer.Admin.Core.Application.Contracts.Api;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Api;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Api
{
    public class ApiService : ApplicationService, IApiService
    {
        private readonly IApiRepository _apiRepository;

        public ApiService(IApiRepository moduleRepository)
        {
            _apiRepository = moduleRepository;
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseOutput<ApiGetOutput>> GetAsync(Guid id)
        {
            return ResponseOutput.Succees(await _apiRepository.GetAsync(expression: x => x.Id == id, selector: x => new ApiGetOutput
            {
                Id = x.Id,
                Description = x.Description,
                Enabled = x.Enabled,
                HttpMethods = x.HttpMethods,
                Label = x.Label,
                ParentId = x.ParentId,
                Path = x.Path,
            }));
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<ResponseOutput<List<ApiListOutput>>> GetListAsync(string key)
        {
            Expression<Func<Ad_ApiEntity, bool>> expression = x => true;
            if (!key.IsNullOrEmpty())
            {
                expression = expression.And(a => a.Path.Contains(key) || a.Label.Contains(key));
            }
            return await _apiRepository.GetResponseOutputListAsync(expression, x => new ApiListOutput
            {
                Id = x.Id,
                Description = x.Description,
                Enabled = x.Enabled,
                HttpMethods = x.HttpMethods,
                Label = x.Label,
                ParentId = x.ParentId,
                Path = x.Path,
                Name = x.Name,
            });
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<ApiListOutput>>> GetPageListAsync(PageInput<ApiInput> input)
        {
            var key = input.Filter?.Label;
            Expression<Func<Ad_ApiEntity, bool>> expression = x => true;
            if (!key.IsNullOrEmpty())
            {
                expression = expression.And(a => a.Path.Contains(key) || a.Label.Contains(key));
            }
            return await _apiRepository.GetResponseOutputPageListAsync(expression, x => new ApiListOutput
            {
                Id = x.Id,
                Description = x.Description,
                Enabled = x.Enabled,
                HttpMethods = x.HttpMethods,
                Label = x.Label,
                ParentId = x.ParentId,
                Path = x.Path,
                Name = x.Name,
            }, x => x.OrderByDescending(p => p.CreationTime), input);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> AddAsync(ApiAddInput input)
        {
            var entity = ObjectMapper.Map<ApiAddInput, Ad_ApiEntity>(input);
            await _apiRepository.InsertAsync(entity);
            return ResponseOutput.Succees("添加成功");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateAsync(ApiUpdateInput input)
        {
            var entity = await _apiRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new BusinessException("接口不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _apiRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _apiRepository.DeleteAsync(id);
            return ResponseOutput.Succees("删除成功");
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _apiRepository.DeleteManyAsync(ids);
            return ResponseOutput.Succees("删除成功！");
        }
    }
}