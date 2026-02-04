using Domain.Ports.Repository;
using Infra.Data.Context;
using Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Tools;
using Microsoft.OpenApi.Models;
using System;
using Application.Services;
using Domain.Ports.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IPropostaSeguroRepository, PropostaSeguroRepository>();
builder.Services.AddScoped<IPropostaService, PropostaService>();

builder.Services.AddControllers();builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Proposta Seguro API",
        Version = "v1",
        Description = "API para gerenciar propostas 'de seguro"
    });
});

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
));

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



