using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class LibrosDBContext : DbContext
    {
        public LibrosDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set;  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Disponible = true },
                new Libro { Id = 2, Titulo = "1984", Autor = "George Orwell", Disponible = true },
                new Libro { Id = 3, Titulo = "El principito", Autor = "Antoine de Saint-Exupéry", Disponible = true },
                new Libro { Id = 4, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", Disponible = true },
                new Libro { Id = 5, Titulo = "Harry Potter y la piedra filosofal", Autor = "J.K. Rowling", Disponible = true },
                new Libro { Id = 6, Titulo = "El código Da Vinci", Autor = "Dan Brown", Disponible = true },
                new Libro { Id = 7, Titulo = "Sapiens: De animales a dioses", Autor = "Yuval Noah Harari", Disponible = true },
                new Libro { Id = 8, Titulo = "Los juegos del hambre", Autor = "Suzanne Collins", Disponible = true },
                new Libro { Id = 9, Titulo = "Crónica de una muerte anunciada", Autor = "Gabriel García Márquez", Disponible = true },
                new Libro { Id = 10, Titulo = "El Hobbit", Autor = "J.R.R. Tolkien", Disponible = true }
            );
        }
    }
}
