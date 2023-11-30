using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


//using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:8000");
