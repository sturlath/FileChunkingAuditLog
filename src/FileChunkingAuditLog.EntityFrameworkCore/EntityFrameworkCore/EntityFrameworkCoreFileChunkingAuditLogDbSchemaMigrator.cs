using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FileChunkingAuditLog.Data;
using Volo.Abp.DependencyInjection;

namespace FileChunkingAuditLog.EntityFrameworkCore;

public class EntityFrameworkCoreFileChunkingAuditLogDbSchemaMigrator
    : IFileChunkingAuditLogDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFileChunkingAuditLogDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the FileChunkingAuditLogDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FileChunkingAuditLogDbContext>()
            .Database
            .MigrateAsync();
    }
}
