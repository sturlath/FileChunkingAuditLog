using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FileChunkingAuditLog.Blazor;

[Dependency(ReplaceServices = true)]
public class FileChunkingAuditLogBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FileChunkingAuditLog";
}
