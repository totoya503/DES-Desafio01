using Microsoft.EntityFrameworkCore;
using DES___Desafio_1.Models;

var builder = WebApplication.CreateBuilder(args);
// Define la carpeta base de ejecución para que |DataDirectory| apunte al directorio local del proyecto
string basePath = AppDomain.CurrentDomain.BaseDirectory;
AppDomain.CurrentDomain.SetData("DataDirectory", basePath);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")));

var app = builder.Build();