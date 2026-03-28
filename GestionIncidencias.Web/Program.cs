using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


namespace GestionIncidencias.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args); builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp => new HttpClient

            {
                BaseAddress = new Uri("https://localhost:7013/")
            });
            await builder.Build().RunAsync();
        }
    }
}

