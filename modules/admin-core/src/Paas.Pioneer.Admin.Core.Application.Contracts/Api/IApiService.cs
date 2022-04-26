using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Api
{
    /// <summary>
    /// 接口服务
    /// </summary>
    public interface IApiService : IApplicationService
    {
        /// <summary>
        /// 获得一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiGetOutput> GetAsync(Guid id);

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<List<ApiListOutput>> GetListAsync(string key);

        /// <summary>
        /// 获得分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Page<ApiListOutput>> GetPageListAsync(PageInput<ApiInput> model);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddAsync(ApiAddInput input);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAsync(ApiUpdateInput input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}