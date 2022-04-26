using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Paas.Pioneer.Admin.Core.Domain.DictionaryType;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.DictionaryType
{
    public class DictionaryTypeService : ApplicationService, IDictionaryTypeService
    {
        private readonly IDictionaryTypeRepository _dictionaryTypeRepository;
        private readonly IDictionaryRepository _dictionaryRepository;

        public DictionaryTypeService(IDictionaryTypeRepository dictionaryTypeRepository,
            IDictionaryRepository dictionaryRepository)
        {
            _dictionaryTypeRepository = dictionaryTypeRepository;
            _dictionaryRepository = dictionaryRepository;
        }

        public async Task<IResponseOutput> AddAsync(DictionaryTypeAddInput input)
        {
            if (await _dictionaryTypeRepository.AnyAsync(x => x.Code == input.Code))
            {
                throw new BusinessException("字典类型编码已存在！");
            }
            var dictionaryType = ObjectMapper.Map<DictionaryTypeAddInput, Ad_DictionaryTypeEntity>(input);
            await _dictionaryTypeRepository.InsertAsync(dictionaryType);
            return ResponseOutput.Succees("添加成功");
        }

        public async Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _dictionaryTypeRepository.DeleteAsync(x => ids.Contains(x.Id));
            return ResponseOutput.Succees("删除成功！");
        }

        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            //删除字典数据
            await _dictionaryRepository.DeleteAsync(a => a.DictionaryTypeId == id);

            //删除字典类型
            await _dictionaryTypeRepository.DeleteAsync(id);
            return ResponseOutput.Succees("删除成功！");
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseOutput<DictionaryTypeGetOutput>> GetAsync(Guid id)
        {
            var result = await _dictionaryTypeRepository.GetAsync(p => p.Id == id, x => new DictionaryTypeGetOutput()
            {
                Id = x.Id,
                Code = x.Code,
                Description = x.Description,
                Enabled = x.Enabled,
                Name = x.Name,
            });
            return ResponseOutput.Succees(result);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<DictionaryTypeOutput>>> GetPageListAsync(PageInput<DictionaryTypeInput> model)
        {
            var data = await _dictionaryTypeRepository.GetPageListAsync(model);
            return ResponseOutput.Succees(data);
        }

        public async Task<IResponseOutput> UpdateAsync(DictionaryTypeUpdateInput input)
        {
            var entity = await _dictionaryTypeRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new BusinessException("数据字典不存在！");
            }
            if (await _dictionaryTypeRepository.AnyAsync(x => x.Id != input.Id && x.Code == input.Code))
            {
                throw new BusinessException("字典类型编码已存在！");
            }
            ObjectMapper.Map(input, entity);
            await _dictionaryTypeRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功");
        }
    }
}
