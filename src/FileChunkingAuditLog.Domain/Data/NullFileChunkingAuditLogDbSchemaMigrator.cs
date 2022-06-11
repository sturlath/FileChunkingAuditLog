using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FileChunkingAuditLog.Data;

/* This is used if database provider does't define
 * IFileChunkingAuditLogDbSchemaMigrator implementation.
 */
public class NullFileChunkingAuditLogDbSchemaMigrator : IFileChunkingAuditLogDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
