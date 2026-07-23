using System.ComponentModel.DataAnnotations;

namespace DES___Desafio_1.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
            = new List<Empleado>();
    }
}