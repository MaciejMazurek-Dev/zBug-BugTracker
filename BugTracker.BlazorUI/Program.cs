using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Handlers;
using BugTracker.BlazorUI.Providers;
using BugTracker.BlazorUI.Services;
using BugTracker.BlazorUI.Services.HttpClientBase;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

namespace BugTracker.BlazorUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddTransient<AuthMessageHandler>();
            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7082"))
                .AddHttpMessageHandler<AuthMessageHandler>();

            builder.Services.AddAuthorizationCore();

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<CustomAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IIssuePriorityService, IssuePriorityService>();
            builder.Services.AddScoped<IIssueTypeService, IssueTypeService>();
            builder.Services.AddScoped<IIssueService, IssueService>();
            builder.Services.AddScoped<IIssueStatusService, IssueStatusService>();
            builder.Services.AddScoped<IUserService, UserService>();

            await builder.Build().RunAsync();
        }
    }
}
