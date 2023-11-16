using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReAddUnitPriceFieldToFoodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Foods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Foods");
        }
    }
}
