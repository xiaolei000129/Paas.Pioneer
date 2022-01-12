using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Admin.Core.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreAdminsDbSchemaMigrator
        : IAdminsDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAdminsDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AdminsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AdminsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
