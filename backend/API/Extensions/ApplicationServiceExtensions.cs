using Core.Entities;
using Core.Interfases;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;
public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost", builder =>
                builder.AllowAnyOrigin() // Permite cualquier origen
                       .AllowAnyMethod()
                       .AllowAnyHeader());
        });


    public static void AddAplicacionServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Usar CORS
        app.UseCors("AllowLocalhost");

        // Otros middlewares
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
