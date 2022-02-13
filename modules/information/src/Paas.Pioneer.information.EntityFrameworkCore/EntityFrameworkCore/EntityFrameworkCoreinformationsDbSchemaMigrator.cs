using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.information.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.information.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreinformationsDbSchemaMigrator
        : IinformationsDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreinformationsDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the informationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<informationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
