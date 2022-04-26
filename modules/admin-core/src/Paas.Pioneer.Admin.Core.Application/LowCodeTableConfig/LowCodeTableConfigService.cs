using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.LowCodeTableConfig
{
    public class LowCodeTableConfigService : ApplicationService, ILowCodeTableConfigService
    {
        /// <summary>
        /// 低代码表格配置仓储
        /// </summary>
        private readonly ILowCodeTableConfigRepository _lowCodeTableConfigRepository;

        public LowCodeTableConfigService(
           ILowCodeTableConfigRepository lowCodeTableConfigRepository)
        {
            _lowCodeTableConfigRepository = lowCodeTableConfigRepository;
        }

        public async Task<IResponseOutput> AddLowCodeTableConfigAsync(AddLowCodeTableConfigInput input)
        {
            // 验证是否已存在
            bool isExist = await _lowCodeTableConfigRepository.AnyAsync(x => x.ColumnName == input.PropertyName);
            if (isExist)
                return ResponseOutput.Error<bool>(msg: "已经存在该字段");

            var entity = ObjectMapper.Map<AddLowCodeTableConfigInput, Ad_LowCodeTableConfigEntity>(input);
            await _lowCodeTableConfigRepository.InsertAsync(entity);
            return ResponseOutput.Succees(true);
        }

        public async Task<IResponseOutput> EditLowCodeTableConfigAsync(List<EditLowCodeTableConfigInput> inputList)
        {
            var lowCodeTableId = inputList.FirstOrDefault().LowCodeTableId;
            await _lowCodeTableConfigRepository.DeleteAsync(x => x.LowCodeTableId == lowCodeTableId);
            var addEntitys = ObjectMapper.Map<List<EditLowCodeTableConfigInput>, List<Ad_LowCodeTableConfigEntity>>(inputList);
            if (addEntitys.Any())
            {
                await _lowCodeTableConfigRepository.InsertManyAsync(addEntitys);
            }
            return ResponseOutput.Succees(true);
        }

        public async Task<IResponseOutput> DelLowCodeTableConfigAsync(Guid id)
        {
            await _lowCodeTableConfigRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees(true);
        }

        public async Task<ResponseOutput<Page<LowCodeTableConfigOutput>>> GetLowCodeTableConfigPageListAsync(PageInput<GetLowCodeTableConfigPadedInput> input)
        {
            var data = await _lowCodeTableConfigRepository.GetLowCodeTableConfigPageListAsync(input);
            return ResponseOutput.Succees(data);
        }
    }
}
