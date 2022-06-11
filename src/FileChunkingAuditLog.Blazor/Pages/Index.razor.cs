namespace FileChunkingAuditLog.Blazor.Pages;

using Microsoft.Extensions.Options;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using Volo.Abp.Http.Client;

public partial class Index
{
    public Index(IOptions<AbpRemoteServiceOptions> abpRemoteServiceOptions)
    {
        this.abpRemoteServiceOptions = abpRemoteServiceOptions.Value;
        var baseUrl = this.abpRemoteServiceOptions.RemoteServices.GetConfigurationOrDefault("Default").BaseUrl;
        saveUrl = $"{baseUrl}/api/app/file-upload/Save";

        RecordingBlobName = Guid.NewGuid().ToString();
    }

    SfUploader uploader;
    private readonly AbpRemoteServiceOptions abpRemoteServiceOptions;
    private readonly string saveUrl;
    private double TotalFileSize { get; set; }
    private string RecordingBlobName { get; set; }

    private void OnSyncfusionFileUploadSelect(SelectedEventArgs args)
    {
        TotalFileSize = args.FilesData[0].Size;
        args.CurrentRequest = new List<object> { new { RecordingBlobName }, new { TotalFileSize } };
    }
}
