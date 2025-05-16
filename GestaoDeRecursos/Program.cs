using ERP.Data;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados
builder.Services.AddDbContext<GDRContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// Adicionando servi�os ao container
builder.Services.AddScoped<EntityEmpresa>();
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

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do Kestrel para rodar apenas HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Somente HTTP na porta 5000
});

var app = builder.Build();

// Executar Migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GDRContext>();
    dbContext.Database.Migrate(); // Aplica as migrations
}

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

// **Removido app.UseHttpsRedirection(); para evitar erro de certificado**
app.UseAuthorization();
app.MapControllers();

// Rodando apenas em HTTP na porta 5000
app.Run("http://0.0.0.0:5000");
