using FileChunkingAuditLog.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FileChunkingAuditLog.Blazor;

public abstract class FileChunkingAuditLogComponentBase : AbpComponentBase
{
    protected FileChunkingAuditLogComponentBase()
    {
        LocalizationResource = typeof(FileChunkingAuditLogResource);
    }
}
