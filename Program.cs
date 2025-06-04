using CustomerApi.Application.Services;
using CustomerApi.Domain.Interfaces;
using CustomerApi.Infrastructure.Context;
using CustomerApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; // Informa a versão da API nas respostas
    options.AssumeDefaultVersionWhenUnspecified = true; // Assume a versão padrão se não for especificada
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0); // Define a versão padrão da API
    options.ApiVersionReader = new HeaderApiVersionReader("x-api-version"); // Lê a versão da API do cabeçalho "x-api-version"
});

builder.Services.AddDbContext<ClienteDbContext>(options =>
    options.UseInMemoryDatabase("CustomerDb"));

// Add services to the container.
builder.Services.AddControllers();

// Configurar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Registrar os serviços da aplicação
builder.Services.AddScoped<ClienteService>();

// Registrar os repositórios da aplicação
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// Registrar controllers
builder.Services.AddControllers();


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

app.MapControllers();

app.Run();
