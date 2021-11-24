namespace Shift.Client;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        app.UseStaticFiles();

        app.MapFallbackToFile("index.html");

        await app.RunAsync();
    }
}

