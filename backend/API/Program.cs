using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Add services to the container.
builder.Services.ConfigureCors(builder.Configuration);
builder.Services.AddAplicacionServices();

builder.Services.AddControllers();

// Set up the DbContext with the connection string
builder.Services.AddDbContext<Context>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DbConnection");
    options.UseNpgsql(connectionString);  // We use PostgreSQL here.
});

// Force automatically generated paths (as with [controller]) to be lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the application middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<Infrastructure.Data.Context>();
        await context.Database.MigrateAsync(); 
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration");
    }
}

var policyName = builder.Configuration.GetSection("CorsSettings:PolicyName").Get<string>();

app.UseRouting();
app.UseCors(policyName);
app.UseAuthorization();
app.MapControllers();

app.Run();
