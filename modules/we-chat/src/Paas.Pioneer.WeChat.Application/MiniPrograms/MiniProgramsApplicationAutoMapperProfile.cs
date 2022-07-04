using AutoMapper;
using Paas.Pioneer.WeChat.Domain.MiniPrograms.UserInfos;
using Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.UserInfos.Dtos;

namespace Paas.Pioneer.WeChat.Application.MiniPrograms
{
    public class MiniProgramsApplicationAutoMapperProfile : Profile
    {
        public MiniProgramsApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<UserInfo, UserInfoDto>();
        }
    }
}
