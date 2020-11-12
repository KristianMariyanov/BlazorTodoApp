using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTodoApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<BlazorTodoApp.App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = "https://accounts.google.com/";
                options.ProviderOptions.RedirectUri = "https://localhost:5001/authentication/login-callback";
                options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:5001/authentication/logout-callback";
                options.ProviderOptions.ClientId = "1048855053233-16qpvegahk2leksb6q2hheoas56pfib9.apps.googleusercontent.com";
                options.ProviderOptions.ResponseType = "id_token";
            });

            await builder.Build().RunAsync();
        }
    }
}
