using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.User;

namespace Paas.Pioneer.Admin.Core.Application.User
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_UserEntity, AuthUserProfileDto>();
            CreateMap<Ad_UserEntity, AuthLoginOutput>();
            CreateMap<Ad_UserEntity, GetUserPageListOutput>();

            CreateMap<UserUpdateBasicInput, Ad_UserEntity>();
            CreateMap<UserChangePasswordInput, Ad_UserEntity>();
            CreateMap<UserAddInput, Ad_UserEntity>();
            CreateMap<UserUpdateInput, Ad_UserEntity>();
        }
    }
}
