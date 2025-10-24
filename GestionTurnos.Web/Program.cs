using GestionTurnos.Web.Configurations;
using GestionTurnos.Web.Interfaces;
using GestionTurnos.Web.Repositories;
using GestionTurnos.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Añadir la base de datos usando el AddDatabase de configurations
builder.Services.AddDatabase(builder.Configuration);

// Poner el repositorio y servicio como instancia global para que sea injectado
builder.Services.AddScoped<IAfiliadoRepository, AfiliadoRepository>();
builder.Services.AddScoped<IAfiliadoServicio, AfiliadoService>();

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
