namespace Shift.Proxy;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

        var app = builder.Build();

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapReverseProxy());

        await app.RunAsync();
    }
}