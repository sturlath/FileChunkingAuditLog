using FileChunkingAuditLog.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FileChunkingAuditLog.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FileChunkingAuditLogEntityFrameworkCoreModule),
    typeof(FileChunkingAuditLogApplicationContractsModule)
    )]
public class FileChunkingAuditLogDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
