using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.WeChat.Domain.Shared.WeChatApps;
using Paas.Pioneer.WeChat.Domain.WeChatAppUsers;
using Paas.Pioneer.WeChat.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.WeChatAppUsers
{
    public class WeChatAppUserRepository : EfCoreRepository<WeChatsDbContext, WeChatAppUser, Guid>, IWeChatAppUserRepository
    {
        public WeChatAppUserRepository(IDbContextProvider<WeChatsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<string> FindUnionIdByOpenIdAsync(Guid weChatAppId, string openId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(x => x.OpenId == openId && x.WeChatAppId == weChatAppId)
                .Select(x => x.UnionId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public virtual async Task<Guid?> FindRecentlyTenantIdAsync(string appId, string openId, bool exceptHost, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Join((await GetDbContextAsync()).WeChatApps, mpUser => mpUser.WeChatAppId, weChatApp => weChatApp.Id,
                    (mpUser, weChatApp) => new { MpUser = mpUser, WeChatApp = weChatApp })
                .Where(x => x.MpUser.OpenId == openId)
                .Where(x => x.WeChatApp.AppId == appId)
                .WhereIf(exceptHost, x => x.WeChatApp.TenantId.HasValue)
                .OrderBy(x => x.MpUser.LastModificationTime == null)
                .ThenByDescending(x => x.MpUser.LastModificationTime)
                .Select(x => x.MpUser.TenantId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyInWeChatAppTypeAsync(WeChatAppType type, Expression<Func<WeChatAppUser, bool>> predicate)
        {
            return await (await GetQueryableAsync())
                .Where(predicate)
                .Join((await GetDbContextAsync()).WeChatApps, mpUser => mpUser.WeChatAppId, weChatApp => weChatApp.Id,
                    (mpUser, weChatApp) => new { MpUser = mpUser, WeChatApp = weChatApp })
                .Where(x => x.WeChatApp.Type == type)
                .AnyAsync();
        }
    }
}