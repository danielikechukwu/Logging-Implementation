var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure logging provider
builder.Logging.ClearProviders();

builder.Logging.AddConsole();

builder.Logging.AddDebug();

// Set specific log levels for different librarues
builder.Logging.SetMinimumLevel(LogLevel.Information); // Default minimum level

builder.Logging.AddFilter("Microsoft", LogLevel.Warning); // For Microsoft.* namespaces

builder.Logging.AddFilter("Microsoft.AspNetCore", LogLevel.Warning); // For ASP.NET Core

builder.Logging.AddFilter("System", LogLevel.Warning); // For System.* namespaces

builder.Logging.AddFilter("TestController.Namespace", LogLevel.Trace); // For your custom namespace

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
