using Microsoft.EntityFrameworkCore;
using ListadeTarefas.Repositorio.Implementação;
using ListadeTarefas.Repositorio.Interfaces;
using ListadeTarefas.Services.Implementações;
using ListadeTarefas.Services.Interfaces;
using ListaTarefasAPI.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
   .AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString: connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();



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
