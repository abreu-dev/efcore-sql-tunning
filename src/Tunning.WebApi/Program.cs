using Tunning.WebApi.Scope;
using Tunning.WebApi.Scope.Extensions;
using Tunning.WebApi.Scope.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomControllers();
builder.Services.AddCustomSwagger();

builder.Logging.AddCustomSerilog();

DependencyResolverService.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
