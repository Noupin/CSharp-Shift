using Microsoft.EntityFrameworkCore;
using Shift.Server.Context;
using Shift.Server.Middleware;
using Shift.Server.Repositories.Implementations;
using Shift.Server.Services.Abstractions;
using Shift.Server.Services.Implementations;
using System.Text.Json.Serialization;

namespace Shift.Server;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ShiftContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("ShiftContext"));
        });
        builder.Services.AddDbContext<FeryvContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("FeryvContext"));
        });
        builder.Services.AddControllers().AddJsonOptions(o =>
        {
            o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.AddSwaggerGen(swagger =>
        {
            swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Shift.Server.xml"));
        });

        builder.Services.AddScoped<ShiftContextMiddleware>();
        builder.Services.AddScoped<FeryvContextMiddleware>();

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IInferenceService, InferenceService>();
        builder.Services.AddScoped<ILoadService, LoadService>();
        builder.Services.AddScoped<IShiftService, ShiftService>();
        builder.Services.AddScoped<ITrainService, TrainService>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddScoped<CategoryRepository>();
        builder.Services.AddScoped<FeryvUserRepository>();
        builder.Services.AddScoped<InferenceWorkerRepository>();
        builder.Services.AddScoped<ShiftCategoryRepository>();
        builder.Services.AddScoped<ShiftRepository>();
        builder.Services.AddScoped<TrainWorkerRepository>();
        builder.Services.AddScoped<UserRepository>();

        var app = builder.Build();

        app.UseMiddleware<ShiftContextMiddleware>();
        app.UseMiddleware<FeryvContextMiddleware>();

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

        //REMOVE FROM PRODUCTION
        using (var scope = app.Services.CreateScope())
        {
            var shiftContext = scope.ServiceProvider.GetRequiredService<ShiftContext>();
            shiftContext.Database.EnsureDeleted();
            shiftContext.Database.Migrate();

            var feryvContext = scope.ServiceProvider.GetRequiredService<FeryvContext>();
            feryvContext.Database.EnsureDeleted();
            feryvContext.Database.Migrate();
        }

        await app.RunAsync();
    }
}
