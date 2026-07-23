using Microsoft.EntityFrameworkCore;

namespace DES___Desafio_1.Models
{
    public class EmpleadosDbContext : DbContext
    {
        public EmpleadosDbContext(DbContextOptions<EmpleadosDbContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nombre = "Recursos Humanos", Descripcion = "Gestión de personal y talento humano" },
                new Departamento { Id = 2, Nombre = "Tecnología", Descripcion = "Soporte e infraestructura tecnológica" },
                new Departamento { Id = 3, Nombre = "Ventas", Descripcion = "Gestión comercial y clientes" }
            );
        }
    }
}