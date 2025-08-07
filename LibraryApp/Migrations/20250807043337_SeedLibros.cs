using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedLibros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] {"Autor", "Disponible", "Titulo" },
                values: new object[,]
                {
                    { "Gabriel García Márquez", true, "Cien años de soledad" },
                    { "George Orwell", true, "1984" },
                    { "Antoine de Saint-Exupéry", true, "El principito" },
                    { "Miguel de Cervantes", true, "Don Quijote de la Mancha" },
                    { "J.K. Rowling", true, "Harry Potter y la piedra filosofal" },
                    { "Dan Brown", true, "El código Da Vinci" },
                    { "Yuval Noah Harari", true, "Sapiens: De animales a dioses" },
                    { "Suzanne Collins", true, "Los juegos del hambre" },
                    { "Gabriel García Márquez", true, "Crónica de una muerte anunciada" },
                    { "J.R.R. Tolkien", true, "El Hobbit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LibroId",
                table: "Prestamos",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Libros_LibroId",
                table: "Prestamos",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Libros_LibroId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_LibroId",
                table: "Prestamos");

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
