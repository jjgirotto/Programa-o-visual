using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESTSCarro_JL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro_JL",
                columns: table => new
                {
                    Carro_JLId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marca_JL = table.Column<int>(type: "int", nullable: false),
                    Modelo_JL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro_JL", x => x.Carro_JLId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carro_JL");
        }
    }
}
