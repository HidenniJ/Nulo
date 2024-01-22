using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactuSystem.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceSaldoPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SaldoPagado",
                table: "Facturas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoPagado",
                table: "Facturas");
        }
    }
}
