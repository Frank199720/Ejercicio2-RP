
using Microsoft.Extensions.DependencyInjection.Extensions;
using RP.Application.ServiceCollection;
using RP.Common.ServiceCollection;
using RPL_Ejercicio2.Middleware;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddApplicationLayer();
builder.Services.AddCommonLayer();

builder.Services.AddTransient<ErrorHandlerMiddleware>();

builder.Services.AddControllers();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
