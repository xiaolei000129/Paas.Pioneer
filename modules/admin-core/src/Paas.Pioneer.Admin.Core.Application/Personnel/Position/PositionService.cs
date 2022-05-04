using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Personnel.Position
{
    public class PositionService : ApplicationService, IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(
            IPositionRepository positionRepository
        )
        {
            _positionRepository = positionRepository;
        }

        public async Task<PositionDataOutput> GetAsync(Guid id)
        {
            var result = await _positionRepository.GetAsync(
                expression: x => x.Id == id,
                selector: x => new PositionDataOutput()
                {
                    Id = x.Id,
                    TenantId = x.TenantId,
                    Name = x.Name,
                    Code = x.Code,
                    Description = x.Description,
                    Enabled = x.Enabled,
                });
            return result;
        }

        public async Task<Page<PositionListOutput>> GetPageListAsync(PageInput<PositionDataOutput> input)
        {
            var key = input.Filter?.Name;

            Expression<Func<Pe_PositionEntity, bool>> predicate = x => true;
            if (!key.IsNullOrEmpty())
            {
                predicate = predicate.And(a => a.Name.Contains(key));
            }

            var list = await _positionRepository.GetResponseOutputPageListAsync(
                expression: predicate,
                selector: x => new PositionListOutput
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Enabled = x.Enabled,
                    Description = x.Description,
                    CreatedTime = x.CreationTime
                }, x => x.OrderByDescending(p => p.Id), input);

            return list;
        }

        public async Task AddAsync(PositionAddInput input)
        {
            var entity = ObjectMapper.Map<PositionAddInput, Pe_PositionEntity>(input);
            await _positionRepository.InsertAsync(entity);
        }

        public async Task UpdateAsync(PositionUpdateInput input)
        {
            var entity = await _positionRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                throw new BusinessException("职位不存在！");
            }

            ObjectMapper.Map(input, entity);
            await _positionRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _positionRepository.DeleteAsync(m => m.Id == id);
        }

        public async Task BatchSoftDeleteAsync(Guid[] ids)
        {
            await _positionRepository.DeleteAsync(x => ids.Contains(x.Id));
        }
    }
}