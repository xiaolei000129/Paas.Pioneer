using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.WeChat.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreWeChatsDbSchemaMigrator
        : IWeChatsDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreWeChatsDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the WeChatsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<WeChatsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
