using Microsoft.EntityFrameworkCore;
using DES___Desafio_1.Models;

var builder = WebApplication.CreateBuilder(args);
// Define la carpeta base de ejecución para que |DataDirectory| apunte al directorio local del proyecto
string basePath = AppDomain.CurrentDomain.BaseDirectory;
AppDomain.CurrentDomain.SetData("DataDirectory", basePath);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<EmpleadosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmpleadosCN")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
