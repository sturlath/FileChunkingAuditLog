using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;

namespace FileChunkingAuditLog.Blazor;

public class Program
{
    public async static Task Main(string[] args)
    {
        // Register Syncfusion license (this is a free license https://www.syncfusion.com/products/communitylicense)
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("somekey");

        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        var application = await builder.AddApplicationAsync<FileChunkingAuditLogBlazorModule>(options =>
        {
            options.UseAutofac();
        });

        var host = builder.Build();

        await application.InitializeApplicationAsync(host.Services);

        await host.RunAsync();
    }
}
