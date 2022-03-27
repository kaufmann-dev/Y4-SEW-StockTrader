using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "STOCKS",
                columns: table => new
                {
                    STOCK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCKS", x => x.STOCK_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRADERS",
                columns: table => new
                {
                    TRADER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRADERS", x => x.TRADER_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRADER_HAS_STOCKS_JT",
                columns: table => new
                {
                    STOCK_ID = table.Column<int>(type: "int", nullable: false),
                    TRADER_ID = table.Column<int>(type: "int", nullable: false),
                    TRADED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PRICE = table.Column<float>(type: "float", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRADER_HAS_STOCKS_JT", x => new { x.TRADER_ID, x.STOCK_ID, x.TRADED_AT });
                    table.ForeignKey(
                        name: "FK_TRADER_HAS_STOCKS_JT_STOCKS_STOCK_ID",
                        column: x => x.STOCK_ID,
                        principalTable: "STOCKS",
                        principalColumn: "STOCK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRADER_HAS_STOCKS_JT_TRADERS_TRADER_ID",
                        column: x => x.TRADER_ID,
                        principalTable: "TRADERS",
                        principalColumn: "TRADER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_STOCKS_NAME",
                table: "STOCKS",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TRADER_HAS_STOCKS_JT_STOCK_ID",
                table: "TRADER_HAS_STOCKS_JT",
                column: "STOCK_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRADER_HAS_STOCKS_JT");

            migrationBuilder.DropTable(
                name: "STOCKS");

            migrationBuilder.DropTable(
                name: "TRADERS");
        }
    }
}
