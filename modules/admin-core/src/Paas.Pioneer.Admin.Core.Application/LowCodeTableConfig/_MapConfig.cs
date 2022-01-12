using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;

namespace Paas.Pioneer.Admin.Core.Application.LowCodeTableConfig
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<AddLowCodeTableConfigInput, Ad_LowCodeTableConfigEntity>();

            CreateMap<EditLowCodeTableConfigInput, Ad_LowCodeTableConfigEntity>();
        }
    }
}
