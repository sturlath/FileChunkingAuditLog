using System.Threading.Tasks;

namespace FileChunkingAuditLog.Data;

public interface IFileChunkingAuditLogDbSchemaMigrator
{
    Task MigrateAsync();
}
