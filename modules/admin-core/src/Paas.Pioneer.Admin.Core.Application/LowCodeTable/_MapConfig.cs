using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTable;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;

namespace Paas.Pioneer.Admin.Core.Application.LowCodeTable
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<AddLowCodeTableInput, Ad_LowCodeTableEntity>();

            CreateMap<EditLowCodeTableInput, Ad_LowCodeTableEntity>();

            CreateMap<Ad_LowCodeTableConfigEntity, LowCodeTableColumnOutput>();

            CreateMap<Ad_LowCodeTableEntity, GenerateCodeLowCodeTableOutput>();

            CreateMap<LowCodeTableColumnOutput, GenerateCodeLowCodeTableConfigOutPut>();
        }
    }
}
