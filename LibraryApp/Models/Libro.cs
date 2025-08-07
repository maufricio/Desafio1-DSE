using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")] 
        public string Titulo { get; set; }
        [Required(ErrorMessage ="El autor es obligatorio.")] 
        public string Autor { get; set; }
        public bool Disponible { get; set; }
    }
    public class Prestamo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Libro")]
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
        public string Estudiante { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaPrestamo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FechaDevolucion { get; set; }

        public Libro? Libro { get; set; } 
    }
}
