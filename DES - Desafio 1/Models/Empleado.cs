using System.ComponentModel.DataAnnotations;

namespace DES___Desafio_1.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        public int DepartamentoId { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Salario { get; set; }

        public string? Descripcion { get; set; }

    }
}