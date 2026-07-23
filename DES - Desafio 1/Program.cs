using Microsoft.EntityFrameworkCore;
using DES___Desafio_1.Models;

var builder = WebApplication.CreateBuilder(args);

// Define la carpeta base de ejecución
string basePath = AppDomain.CurrentDomain.BaseDirectory;
AppDomain.CurrentDomain.SetData("DataDirectory", basePath);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmpleadosDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();