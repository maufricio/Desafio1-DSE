using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required] public string Titulo { get; set; }
        [Required] public string Autor { get; set; }
        public bool Disponible { get; set; }
    }
    public class Prestamo
    {
        public int Id { get; set; }
        [ForeignKey("Libro")] public int LibroId { get; set; }
        [Required] public string Estudiante { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
