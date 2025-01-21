using Microsoft.EntityFrameworkCore;
using WebApi_Associado.Data;
using WebApi_Associado.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// injeta o dbcontext no projeto
builder.Services.AddDbContext<WebApi_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// classes de serviço
builder.Services.AddScoped<AssociadoService>();
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<Associado_EmpresaService>();


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
