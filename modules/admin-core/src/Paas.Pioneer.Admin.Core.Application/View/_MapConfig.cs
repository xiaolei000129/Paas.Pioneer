using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.View
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_ViewEntity, ViewGetOutput>();

            CreateMap<ViewUpdateInput, Ad_ViewEntity>();
            CreateMap<ViewAddInput, Ad_ViewEntity>();
        }
    }
}
