using ERP.Data;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<GDRContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// Adicionando serviços ao container
builder.Services.AddScoped<EntityCompany>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do Kestrel para rodar apenas HTTP na porta 5000
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Somente HTTP na porta 5000
});

var app = builder.Build();

// Executar Migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GDRContext>();
    dbContext.Database.Migrate();
}

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP API V1");
        c.RoutePrefix = string.Empty; // Swagger acessível direto na raiz (ex: http://localhost:5000)
    });
}

app.UseCors("AllowOrigin");

// Não usamos HTTPS
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Rodando apenas HTTP na porta 5000
app.Run("http://0.0.0.0:5000");
