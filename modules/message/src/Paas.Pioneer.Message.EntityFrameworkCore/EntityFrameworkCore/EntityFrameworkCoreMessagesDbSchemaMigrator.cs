using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Message.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Message.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreMessagesDbSchemaMigrator
        : IMessagesDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreMessagesDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MessagesDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MessagesDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
