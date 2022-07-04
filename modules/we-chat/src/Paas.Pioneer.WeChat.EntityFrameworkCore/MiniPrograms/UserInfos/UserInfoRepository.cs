using System;
using Paas.Pioneer.WeChat.Domain.MiniPrograms.UserInfos;
using Paas.Pioneer.WeChat.EntityFrameworkCore.MiniPrograms.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.MiniPrograms.UserInfos
{
    public class UserInfoRepository : EfCoreRepository<IMiniProgramsDbContext, UserInfo, Guid>, IUserInfoRepository
    {
        public UserInfoRepository(IDbContextProvider<IMiniProgramsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}