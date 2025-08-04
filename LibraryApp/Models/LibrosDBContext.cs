using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class LibrosDBContext : DbContext
    {
        public LibrosDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }
    }
}
