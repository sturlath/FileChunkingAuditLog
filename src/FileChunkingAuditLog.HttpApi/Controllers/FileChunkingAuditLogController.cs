using FileChunkingAuditLog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FileChunkingAuditLog.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FileChunkingAuditLogController : AbpControllerBase
{
    protected FileChunkingAuditLogController()
    {
        LocalizationResource = typeof(FileChunkingAuditLogResource);
    }
}
