using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGenero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Productoras",
                columns: table => new
                {
                    IdProductora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProductora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productoras", x => x.IdProductora);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    IdSerie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PortadaUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VideoURl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdProductora = table.Column<int>(type: "int", nullable: false),
                    IdGeneroPrimario = table.Column<int>(type: "int", nullable: false),
                    IdGeneroSecundario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.IdSerie);
                    table.ForeignKey(
                        name: "FK_Series_Generos_IdGeneroPrimario",
                        column: x => x.IdGeneroPrimario,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Generos_IdGeneroSecundario",
                        column: x => x.IdGeneroSecundario,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Productoras_IdProductora",
                        column: x => x.IdProductora,
                        principalTable: "Productoras",
                        principalColumn: "IdProductora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productoras_NombreProductora",
                table: "Productoras",
                column: "NombreProductora",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdGeneroPrimario",
                table: "Series",
                column: "IdGeneroPrimario");

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdGeneroSecundario",
                table: "Series",
                column: "IdGeneroSecundario");

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdProductora",
                table: "Series",
                column: "IdProductora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Productoras");
        }
    }
}
