using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.WeChat.Domain.MiniPrograms.UserInfos
{
    public interface IUserInfoRepository : IRepository<UserInfo, Guid>
    {
    }
}