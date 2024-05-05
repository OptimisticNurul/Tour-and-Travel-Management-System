using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tour_Travel.Migrations
{
    /// <inheritdoc />
    public partial class Script6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourFoods_TourFoodId",
                table: "TourPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourGuides_TourGuideId",
                table: "TourPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourHotels_TourHotelId",
                table: "TourPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourTransports_TourTransportId",
                table: "TourPackages");

            migrationBuilder.AlterColumn<int>(
                name: "TourTransportId",
                table: "TourPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TourHotelId",
                table: "TourPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TourGuideId",
                table: "TourPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TourFoodId",
                table: "TourPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TourFoodIds",
                table: "TourPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "TourGuideIds",
                table: "TourPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "TourHotelIds",
                table: "TourPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "TourTransportIds",
                table: "TourPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourFoods_TourFoodId",
                table: "TourPackages",
                column: "TourFoodId",
                principalTable: "TourFoods",
                principalColumn: "TourFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourGuides_TourGuideId",
                table: "TourPackages",
                column: "TourGuideId",
                principalTable: "TourGuides",
                principalColumn: "TourGuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourHotels_TourHotelId",
                table: "TourPackages",
                column: "TourHotelId",
                principalTable: "TourHotels",
                principalColumn: "TourHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourTransports_TourTransportId",
                table: "TourPackages",
                column: "TourTransportId",
                principalTable: "TourTransports",
                principalColumn: "TourTransportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourFoods_TourFoodId",
                table: "TourPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourGuides_TourGuideId",
                table: "TourPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourHotels_TourHotelId",
                table: "TourPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_TourTransports_TourTransportId",
                table: "TourPackages");

            migrationBuilder.DropColumn(
                name: "TourFoodIds",
                table: "TourPackages");

            migrationBuilder.DropColumn(
                name: "TourGuideIds",
                table: "TourPackages");

            migrationBuilder.DropColumn(
                name: "TourHotelIds",
                table: "TourPackages");

            migrationBuilder.DropColumn(
                name: "TourTransportIds",
                table: "TourPackages");

            migrationBuilder.AlterColumn<int>(
                name: "TourTransportId",
                table: "TourPackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourHotelId",
                table: "TourPackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourGuideId",
                table: "TourPackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourFoodId",
                table: "TourPackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourFoods_TourFoodId",
                table: "TourPackages",
                column: "TourFoodId",
                principalTable: "TourFoods",
                principalColumn: "TourFoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourGuides_TourGuideId",
                table: "TourPackages",
                column: "TourGuideId",
                principalTable: "TourGuides",
                principalColumn: "TourGuideId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourHotels_TourHotelId",
                table: "TourPackages",
                column: "TourHotelId",
                principalTable: "TourHotels",
                principalColumn: "TourHotelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_TourTransports_TourTransportId",
                table: "TourPackages",
                column: "TourTransportId",
                principalTable: "TourTransports",
                principalColumn: "TourTransportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
