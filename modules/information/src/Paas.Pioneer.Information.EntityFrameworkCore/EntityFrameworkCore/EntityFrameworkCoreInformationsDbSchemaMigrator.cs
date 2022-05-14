using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Information.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreInformationsDbSchemaMigrator
        : IInformationsDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreInformationsDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the InformationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<InformationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
