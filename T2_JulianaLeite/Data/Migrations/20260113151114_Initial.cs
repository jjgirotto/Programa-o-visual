using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T2_JulianaLeite.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParqueAutocaravanismo_JL",
                columns: table => new
                {
                    ParqueAutocaravanismo_JLId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome_JL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParqueAutocaravanismo_JL", x => x.ParqueAutocaravanismo_JLId);
                });

            migrationBuilder.CreateTable(
                name: "Autocaravana_JL",
                columns: table => new
                {
                    Autocaravana_JLId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricula_JL = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Diaria_JL = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ParqueAutocaravanismo_JLId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autocaravana_JL", x => x.Autocaravana_JLId);
                    table.ForeignKey(
                        name: "FK_Autocaravana_JL_ParqueAutocaravanismo_JL_ParqueAutocaravanismo_JLId",
                        column: x => x.ParqueAutocaravanismo_JLId,
                        principalTable: "ParqueAutocaravanismo_JL",
                        principalColumn: "ParqueAutocaravanismo_JLId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autocaravana_JL_ParqueAutocaravanismo_JLId",
                table: "Autocaravana_JL",
                column: "ParqueAutocaravanismo_JLId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autocaravana_JL");

            migrationBuilder.DropTable(
                name: "ParqueAutocaravanismo_JL");
        }
    }
}
