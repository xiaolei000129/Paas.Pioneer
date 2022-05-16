using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Workflow.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Workflow.EntityFrameworkCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreWorkflowsDbSchemaMigrator
        : IWorkflowsDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreWorkflowsDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the WorkflowsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<WorkflowsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
