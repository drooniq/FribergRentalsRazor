using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergRentalsRazor.Migrations
{
    /// <inheritdoc />
    public partial class Addingcostperdaytocarmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CostPerDay",
                table: "Car",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPerDay",
                table: "Car");
        }
    }
}
