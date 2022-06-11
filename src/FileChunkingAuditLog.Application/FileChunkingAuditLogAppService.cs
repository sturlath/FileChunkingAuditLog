using System;
using System.Collections.Generic;
using System.Text;
using FileChunkingAuditLog.Localization;
using Volo.Abp.Application.Services;

namespace FileChunkingAuditLog;

/* Inherit your application services from this class.
 */
public abstract class FileChunkingAuditLogAppService : ApplicationService
{
    protected FileChunkingAuditLogAppService()
    {
        LocalizationResource = typeof(FileChunkingAuditLogResource);
    }
}
