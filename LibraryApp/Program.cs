using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibrosDBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("Libros")));

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
    name: "libros",
    pattern: "Libros",
    defaults: new {controller = "Libros", action = "Index"}
    );

app.MapControllerRoute(
    name : "prestamos",
    pattern: "Prestamos/Registrar",
    defaults: new {controller = "Prestamos", action = "Registrar"}
    );

app.MapControllerRoute(
    name: "default", //modificando para que la ruta por defecto sea el Dashboard de Libros
    pattern: "{controller=Libros}/{action=Dashboard}");



app.Run();
