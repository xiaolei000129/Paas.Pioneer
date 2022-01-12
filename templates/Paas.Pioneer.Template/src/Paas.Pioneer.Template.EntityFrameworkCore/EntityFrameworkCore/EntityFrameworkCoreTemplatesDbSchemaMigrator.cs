using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Template.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Template.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreTemplatesDbSchemaMigrator
        : ITemplatesDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTemplatesDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TemplatesDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TemplatesDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
