using Application.Services;
using Domain.Ports.Http;
using Domain.Ports.Service;
using Infra.Data.Context;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Contratação Seguro API",
        Version = "v1",
        Description = "API para Contratação de seguro"
    });
});

builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddHttpClient<IPropostaPort, PropostaApiAdapter>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("PropostaApiURL").Value);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proposta API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
