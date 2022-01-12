using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Hangfire.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Hangfire.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreHangfiresDbSchemaMigrator
        : IHangfiresDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreHangfiresDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HangfiresDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HangfiresDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
