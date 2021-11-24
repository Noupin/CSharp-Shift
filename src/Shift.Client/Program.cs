using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace Shift.Client;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSpaStaticFiles(options => options.RootPath = "ClientApp/build");

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseSpaStaticFiles();
        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";

            if (app.Environment.IsDevelopment())
            {
                spa.UseReactDevelopmentServer("start");
            }
        });

        await app.RunAsync();
    }
}

