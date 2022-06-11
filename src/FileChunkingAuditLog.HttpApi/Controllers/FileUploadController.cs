using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Auditing;

namespace FileChunkingAuditLog.Controllers
{
    [Area("app")]
    [ControllerName("FileUpload")]
    [Route("api/app/file-upload")]
    public class FileUploadController : FileChunkingAuditLogController
    {
        public FileUploadController(IWebHostEnvironment hostingEnv) : base(hostingEnv)
        {
        }

        [AllowAnonymous]
        [DisableAuditing] //<-- This does nothing...
        [HttpPost("[action]")]
        [IgnoreAntiforgeryToken]
        [DisableFormValueModelBinding]
        [DisableRequestSizeLimit]
        public virtual async Task Save(IList<IFormFile> chunkFile)
        {
            /*************************************************************************************/
            /* Each and every Save is written into the AbpAuditLogs table (making it un-usable! */
            /*************************************************************************************/

            var blobName = Response.HttpContext.Request.Headers["RecordingBlobName"].ToString();
            _ = double.TryParse(Response.HttpContext.Request.Headers["TotalFileSize"].ToString(), out double totoalFileSize);

            var folderName = "TempUploads";
            var file = chunkFile[0];
            var fullPahtWithBlobName = hostingEnv.ContentRootPath + $@"\{folderName}\{blobName}";

            try
            {
                if (!Directory.Exists(hostingEnv.ContentRootPath + $@"\{folderName}"))
                {
                    Directory.CreateDirectory(hostingEnv.ContentRootPath + $@"\{folderName}");
                }

                if (!System.IO.File.Exists(fullPahtWithBlobName))
                {
                    using FileStream fs = System.IO.File.Create(fullPahtWithBlobName);
                    await file.CopyToAsync(fs);
                    await fs.FlushAsync();
                }
                else
                {
                    using FileStream fs = System.IO.File.Open(fullPahtWithBlobName, FileMode.Append);
                    await file.CopyToAsync(fs);
                    await fs.FlushAsync();

                    if (fs.Length == totoalFileSize)
                    {
                        fs.Close();
                        try
                        {
                            Logger.LogInformation("Done uploading file!");
                            //Do something with the file!
                        }
                        catch (Exception e)
                        {
                            Logger.LogError(e, "We got the whole video file but something happened when trying to upload it");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Failed to Save the video file");
            }
        }
    }
}
