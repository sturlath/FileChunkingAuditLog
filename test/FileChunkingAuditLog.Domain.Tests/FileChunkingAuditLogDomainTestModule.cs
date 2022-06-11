using FileChunkingAuditLog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FileChunkingAuditLog;

[DependsOn(
    typeof(FileChunkingAuditLogEntityFrameworkCoreTestModule)
    )]
public class FileChunkingAuditLogDomainTestModule : AbpModule
{

}
