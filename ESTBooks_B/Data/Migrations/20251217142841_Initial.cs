using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESTBooks_B.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookStore_B",
                columns: table => new
                {
                    BookStore_BId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location_B = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStore_B", x => x.BookStore_BId);
                });

            migrationBuilder.CreateTable(
                name: "Book_B",
                columns: table => new
                {
                    Book_BId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title_B = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price_B = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Units_B = table.Column<int>(type: "int", nullable: false),
                    Category_B = table.Column<int>(type: "int", nullable: false),
                    Store_BId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_B", x => x.Book_BId);
                    table.ForeignKey(
                        name: "FK_Book_B_BookStore_B_Store_BId",
                        column: x => x.Store_BId,
                        principalTable: "BookStore_B",
                        principalColumn: "BookStore_BId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_B_Store_BId",
                table: "Book_B",
                column: "Store_BId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_B");

            migrationBuilder.DropTable(
                name: "BookStore_B");
        }
    }
}
