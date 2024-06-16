using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGPI.Application.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class FinancialProductTransactionMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "financial_product_details",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    financial_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    product_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_product_details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "financial_product_transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_detail_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    transaction_type = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    create_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_product_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_financial_product_transactions_financial_product_details_id",
                        column: x => x.id,
                        principalTable: "financial_product_details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "financial_product_transactions");

            migrationBuilder.DropTable(
                name: "financial_product_details");
        }
    }
}
