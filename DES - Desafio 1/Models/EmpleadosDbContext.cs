using Microsoft.EntityFrameworkCore;

namespace DES___Desafio_1.Models
{
    public class EmpleadosDbContext : DbContext
    {
        public EmpleadosDbContext(
            DbContextOptions<EmpleadosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DEPARTAMENTOS

            modelBuilder.Entity<Departamento>().HasData(

                new Departamento
                {
                    Id = 1,
                    Nombre = "Recursos Humanos",
                    Descripcion = "Gestión de personal y talento humano"
                },

                new Departamento
                {
                    Id = 2,
                    Nombre = "Tecnología",
                    Descripcion = "Soporte e infraestructura tecnológica"
                },

                new Departamento
                {
                    Id = 3,
                    Nombre = "Ventas",
                    Descripcion = "Gestión comercial y clientes"
                }
            );

            // EMPLEADOS

            modelBuilder.Entity<Empleado>().HasData(

                new Empleado
                {
                    EmpleadoId = 1,
                    Nombre = "John Doe",
                    FechaNacimiento = new DateTime(1985, 5, 20),
                    FechaContratacion = new DateTime(2010, 8, 15),
                    Salario = 50000,
                    DepartamentoId = 1,
                    Descripcion = null
                },

                new Empleado
                {
                    EmpleadoId = 2,
                    Nombre = "Jane Smith",
                    FechaNacimiento = new DateTime(1990, 3, 10),
                    FechaContratacion = new DateTime(2015, 1, 25),
                    Salario = 70000,
                    DepartamentoId = 2,
                    Descripcion = null
                },

                new Empleado
                {
                    EmpleadoId = 3,
                    Nombre = "Mark Johnson",
                    FechaNacimiento = new DateTime(1982, 11, 22),
                    FechaContratacion = new DateTime(2012, 6, 18),
                    Salario = 55000,
                    DepartamentoId = 3,
                    Descripcion = null
                },

                new Empleado
                {
                    EmpleadoId = 4,
                    Nombre = "Emily Davis",
                    FechaNacimiento = new DateTime(1978, 7, 30),
                    FechaContratacion = new DateTime(2005, 10, 12),
                    Salario = 75000,
                    DepartamentoId = 1,
                    Descripcion = null
                },

                new Empleado
                {
                    EmpleadoId = 5,
                    Nombre = "Michael Brown",
                    FechaNacimiento = new DateTime(1995, 12, 5),
                    FechaContratacion = new DateTime(2020, 4, 15),
                    Salario = 60000,
                    DepartamentoId = 2,
                    Descripcion = null
                }
            );
        }
    }
}