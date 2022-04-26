using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary
{
    public interface IDictionaryService : IApplicationService
    {
        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DictionaryGetOutput> GetAsync(Guid id);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Page<DictionaryPageListOutput>> GetPageListAsync(PageInput<DictionaryInput> model);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddAsync(DictionaryAddInput input);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAsync(DictionaryUpdateInput input);

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
        Task BatchSoftDeleteAsync(Guid[] ids);
    }
}