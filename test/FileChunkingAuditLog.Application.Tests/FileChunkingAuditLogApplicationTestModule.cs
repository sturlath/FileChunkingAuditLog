using Volo.Abp.Modularity;

namespace FileChunkingAuditLog;

[DependsOn(
    typeof(FileChunkingAuditLogApplicationModule),
    typeof(FileChunkingAuditLogDomainTestModule)
    )]
public class FileChunkingAuditLogApplicationTestModule : AbpModule
{

}
