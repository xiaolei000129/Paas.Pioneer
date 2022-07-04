using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms.UserInfos;
using System;
using Volo.Abp.Application.Dtos;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.UserInfos.Dtos
{
    [Serializable]
    public class UserInfoDto : FullAuditedEntityDto<Guid>, IUserInfo
    {
        public Guid UserId { get; set; }

        public string NickName { get; set; }

        public byte Gender { get; set; }

        public string Language { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string AvatarUrl { get; set; }
    }
}