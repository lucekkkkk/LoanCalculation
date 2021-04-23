using LoanCalculation.Helpers;
using LoanCalculation.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDM0ODkzQDMxMzgyZTMyMmUzMFMxWU5sSStTdDRUSWhJTy9iMWlnaWxPMDlVSGVwZ0hRbTFpc2ZqZGJVTVE9");

            builder.Services.AddTransient<ICalculateHelper, CalculateHelper>();
            builder.Services.AddTransient<IFormatHelper, FormatHelper>();
            builder.Services.AddSingleton<LoanCalculatorService>();

            await builder.Build().RunAsync();
        }
    }
}
