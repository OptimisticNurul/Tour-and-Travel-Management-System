using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tour_Travel.Migrations
{
    /// <inheritdoc />
    public partial class script4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromotionCode",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionCode",
                table: "TourBookings");
        }
    }
}
