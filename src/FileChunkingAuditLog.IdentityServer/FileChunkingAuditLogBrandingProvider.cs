using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FileChunkingAuditLog;

[Dependency(ReplaceServices = true)]
public class FileChunkingAuditLogBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FileChunkingAuditLog";
}
