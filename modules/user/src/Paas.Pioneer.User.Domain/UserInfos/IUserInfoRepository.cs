using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.User.Domain.UserInfos
{
    public interface IUserInfoRepository : IRepository<UserInfo, Guid>
    {
    }
}