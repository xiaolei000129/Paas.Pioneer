using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.User.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.User.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreUsersDbSchemaMigrator
        : IUsersDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreUsersDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the UsersDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<UsersDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
