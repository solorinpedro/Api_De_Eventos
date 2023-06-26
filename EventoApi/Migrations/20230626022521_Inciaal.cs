using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoApi.Migrations
{
    /// <inheritdoc />
    public partial class Inciaal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    lugar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CantidadTicket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Evento__3213E83FF4FDC094", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    area = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    nombreusuario = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    nombreevento = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ticket__3213E83FA4B3483D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__3213E83F9E320C8A", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
