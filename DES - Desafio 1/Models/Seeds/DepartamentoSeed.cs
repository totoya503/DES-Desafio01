using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DES___Desafio_1.Models.Seeds
{
    public class DepartamentoSeed : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasData(
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
        }
    }
}