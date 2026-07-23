using Microsoft.EntityFrameworkCore;
using DES___Desafio_1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")));

var app = builder.Build();