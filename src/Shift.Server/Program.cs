using System.Text.Json.Serialization;

namespace Shift.Server;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        builder.Services.AddSwaggerGen(swagger => swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Shift.Server.xml")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(options => options.RouteTemplate = "{documentName}/swagger.json");
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Shift");
                options.RoutePrefix = "";
            });
        }

        app.MapControllers();

        await app.RunAsync();
    }
}
