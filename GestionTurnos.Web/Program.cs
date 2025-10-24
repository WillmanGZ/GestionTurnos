using GestionTurnos.Web.Configurations;
using GestionTurnos.Web.Interfaces;
using GestionTurnos.Web.Repositories;
using GestionTurnos.Web.Services;

// Crear el builder de la aplicaci�n
var builder = WebApplication.CreateBuilder(args);

// A�adir la base de datos usando el AddDatabase de configurations
builder.Services.AddDatabase(builder.Configuration);

// Poner el repositorio y servicio como instancia global para que pueda ser injectado
builder.Services.AddScoped<IAfiliadoRepository, AfiliadoRepository>();
builder.Services.AddScoped<IAfiliadoServicio, AfiliadoService>();

// Configura el MVC Framework (configura controllers, registra las vistas, activa el model binding y validation, etc)
builder.Services.AddControllersWithViews();

// Montar la aplicaci�n
var app = builder.Build();

app.UseHttpsRedirection(); // Fuerza HTTPS
app.UseStaticFiles(); // Permite servir CSS, JS, im�genes
app.UseRouting();  // Activa el sistema de rutas MVC
app.MapControllerRoute(name: "default", pattern: "{controller=Afiliado}/{action=Index}/{id?}"); // Enruta hacia los controladores

// Corre la aplicaci�n
app.Run();
