using GestionTurnos.Web.Data;
using GestionTurnos.Web.Interfaces;
using GestionTurnos.Web.Repositories;
using GestionTurnos.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables del archivo .env
DotNetEnv.Env.Load();

var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var name = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var pass = Environment.GetEnvironmentVariable("DB_PASS");

// Construir la cadena de conexión dinámicamente
var connectionString = $"Host={host};Port={port};Database={name};Username={user};Password={pass}";

// Registrar el contexto
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Poner el repositorio y servicio como instancia global para que sea injectado
builder.Services.AddScoped<IAfiliadoRepository, AfiliadoRepository>();
builder.Services.AddScoped<IAfiliadoServicio, AfiliadoService>();

// Forma usando el appsettings.json
// builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Afiliados",
    pattern: "{controller=Afiliado}/{action=Index}/{id?}");

app.Run();
