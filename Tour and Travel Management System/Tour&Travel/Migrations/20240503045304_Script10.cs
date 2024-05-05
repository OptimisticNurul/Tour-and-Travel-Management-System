using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tour_Travel.Migrations
{
    /// <inheritdoc />
    public partial class Script10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Promotions_PromotionId",
                table: "TourBookings");

            migrationBuilder.AlterColumn<int>(
                name: "PromotionId",
                table: "TourBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Promotions_PromotionId",
                table: "TourBookings",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "PromotionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Promotions_PromotionId",
                table: "TourBookings");

            migrationBuilder.AlterColumn<int>(
                name: "PromotionId",
                table: "TourBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Promotions_PromotionId",
                table: "TourBookings",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "PromotionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
