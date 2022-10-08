global using FastEndpoints;
using Digimon.Api.Middleware;
using Digimon.Application;
using Digimon.Infrastructure;
using FastEndpoints.Swagger;
using Serilog;


var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(c =>
    {
        c.Path = "/swagger/swagger.json";
    });
    app.UseSwaggerUi3(c =>
    {

        c.DocumentPath = "/swagger/swagger.json";
    });
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseFastEndpoints();
app.Run();