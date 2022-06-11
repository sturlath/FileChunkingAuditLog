using FileChunkingAuditLog.Localization;
using Microsoft.AspNetCore.Hosting;
using Volo.Abp.AspNetCore.Mvc;
namespace FileChunkingAuditLog.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FileChunkingAuditLogController : AbpControllerBase
{
    protected FileChunkingAuditLogController(IWebHostEnvironment hostingEnv)
    {
        LocalizationResource = typeof(FileChunkingAuditLogResource);
        this.hostingEnv = hostingEnv;
    }
    public IWebHostEnvironment hostingEnv;


}
