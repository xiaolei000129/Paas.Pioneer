using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.User;

namespace Paas.Pioneer.Admin.Core.Application.Auth
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_UserEntity, AuthLoginOutput>();
        }
    }
}
