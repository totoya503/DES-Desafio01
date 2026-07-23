using Microsoft.EntityFrameworkCore;
using DES___Desafio_1.Models;

namespace DES___Desafio_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}