using MarcasAutosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

// Add services to the container.
builder.Services.AddControllers();

// Autorization (para evitar el error de UseAuthorization)
builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MarcasAutos API",
        Version = "v1"
    });
});

// DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Activa tus endpoints como /api/MarcasAutos

app.Run();
