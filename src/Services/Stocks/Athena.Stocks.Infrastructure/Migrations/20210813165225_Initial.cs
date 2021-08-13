using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Athena.Stocks.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stocks");

            migrationBuilder.CreateTable(
                name: "StockExchanges",
                schema: "stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ForwardPeRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockExchangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MarketCapValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MarketCapCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    TotalRevenueValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalRevenueCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_StockExchanges_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalSchema: "stocks",
                        principalTable: "StockExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockExchangeId",
                schema: "stocks",
                table: "Stocks",
                column: "StockExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "stocks");

            migrationBuilder.DropTable(
                name: "StockExchanges",
                schema: "stocks");
        }
    }
}
