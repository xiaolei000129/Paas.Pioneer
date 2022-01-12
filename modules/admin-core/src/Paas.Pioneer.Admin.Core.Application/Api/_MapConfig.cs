using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Api
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_ApiEntity, ApiGetOutput>();
            CreateMap<Ad_ApiEntity, ApiListOutput>();
            CreateMap<ApiUpdateInput, Ad_ApiEntity>();
            CreateMap<ApiAddInput, Ad_ApiEntity>();
        }
    }
}
