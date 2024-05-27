using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiDotnetExample.Application;
using WebApiDotnetExample.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PessoaRepository>();
builder.Services.AddScoped<PessoaApplication>();

builder.Services.AddControllers();

// Configurar o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiDotnetExample", Version = "v1" });
});

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDotnetExample v1");
        c.RoutePrefix = string.Empty;  // Configurar Swagger na raiz (opcional)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
