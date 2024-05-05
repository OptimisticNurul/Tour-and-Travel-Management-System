using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tour_Travel.Migrations
{
    /// <inheritdoc />
    public partial class Script3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_Bookings_BookingId",
                table: "Refunds");

            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Bookings_BookingId",
                table: "TourBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Promotions_PromotionId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Bookings_BookingId",
                table: "TransactionHistories");

            migrationBuilder.DropTable(
                name: "FlightAvalabilities");

            migrationBuilder.DropTable(
                name: "FlightCancellations");

            migrationBuilder.DropTable(
                name: "FlightSeatReservations");

            migrationBuilder.DropTable(
                name: "TravelDocuments");

            migrationBuilder.DropTable(
                name: "FlightBookings");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Tours_PromotionId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TotalSeat",
                table: "TourTransports");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "TransactionHistories",
                newName: "TourBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistories_BookingId",
                table: "TransactionHistories",
                newName: "IX_TransactionHistories_TourBookingId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "TourBookings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TourBookings_BookingId",
                table: "TourBookings",
                newName: "IX_TourBookings_UserId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Refunds",
                newName: "TourBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Refunds_BookingId",
                table: "Refunds",
                newName: "IX_Refunds_TourBookingId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Payments",
                newName: "TourBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                newName: "IX_Payments_TourBookingId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "TourBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "TourBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "TourBookings",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_PromotionId",
                table: "TourBookings",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_TourBookings_TourBookingId",
                table: "Payments",
                column: "TourBookingId",
                principalTable: "TourBookings",
                principalColumn: "TourBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_TourBookings_TourBookingId",
                table: "Refunds",
                column: "TourBookingId",
                principalTable: "TourBookings",
                principalColumn: "TourBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Promotions_PromotionId",
                table: "TourBookings",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "PromotionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Users_UserId",
                table: "TourBookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_TourBookings_TourBookingId",
                table: "TransactionHistories",
                column: "TourBookingId",
                principalTable: "TourBookings",
                principalColumn: "TourBookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_TourBookings_TourBookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_TourBookings_TourBookingId",
                table: "Refunds");

            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Promotions_PromotionId",
                table: "TourBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Users_UserId",
                table: "TourBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_TourBookings_TourBookingId",
                table: "TransactionHistories");

            migrationBuilder.DropIndex(
                name: "IX_TourBookings_PromotionId",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "TourBookings");

            migrationBuilder.RenameColumn(
                name: "TourBookingId",
                table: "TransactionHistories",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistories_TourBookingId",
                table: "TransactionHistories",
                newName: "IX_TransactionHistories_BookingId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TourBookings",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_TourBookings_UserId",
                table: "TourBookings",
                newName: "IX_TourBookings_BookingId");

            migrationBuilder.RenameColumn(
                name: "TourBookingId",
                table: "Refunds",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Refunds_TourBookingId",
                table: "Refunds",
                newName: "IX_Refunds_BookingId");

            migrationBuilder.RenameColumn(
                name: "TourBookingId",
                table: "Payments",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_TourBookingId",
                table: "Payments",
                newName: "IX_Payments_BookingId");

            migrationBuilder.AddColumn<int>(
                name: "TotalSeat",
                table: "TourTransports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinationAirport = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PricePerSeat = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelDocuments",
                columns: table => new
                {
                    TravelDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelDocuments", x => x.TravelDocumentId);
                    table.ForeignKey(
                        name: "FK_TravelDocuments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightAvalabilities",
                columns: table => new
                {
                    FlightAvalabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightAvalabilities", x => x.FlightAvalabilityId);
                    table.ForeignKey(
                        name: "FK_FlightAvalabilities_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightBookings",
                columns: table => new
                {
                    FlightBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPassengers = table.Column<int>(type: "int", nullable: false),
                    Return = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookings", x => x.FlightBookingId);
                    table.ForeignKey(
                        name: "FK_FlightBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightBookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightCancellations",
                columns: table => new
                {
                    FlightCancellationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightBookingId = table.Column<int>(type: "int", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCancellations", x => x.FlightCancellationId);
                    table.ForeignKey(
                        name: "FK_FlightCancellations_FlightBookings_FlightBookingId",
                        column: x => x.FlightBookingId,
                        principalTable: "FlightBookings",
                        principalColumn: "FlightBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightSeatReservations",
                columns: table => new
                {
                    FlightSeatReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightBookingId = table.Column<int>(type: "int", nullable: false),
                    PassengerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSeatReservations", x => x.FlightSeatReservationId);
                    table.ForeignKey(
                        name: "FK_FlightSeatReservations_FlightBookings_FlightBookingId",
                        column: x => x.FlightBookingId,
                        principalTable: "FlightBookings",
                        principalColumn: "FlightBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_PromotionId",
                table: "Tours",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PromotionId",
                table: "Bookings",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightAvalabilities_FlightId",
                table: "FlightAvalabilities",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_BookingId",
                table: "FlightBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_FlightId",
                table: "FlightBookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCancellations_FlightBookingId",
                table: "FlightCancellations",
                column: "FlightBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PromotionId",
                table: "Flights",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeatReservations_FlightBookingId",
                table: "FlightSeatReservations",
                column: "FlightBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelDocuments_UserId",
                table: "TravelDocuments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_Bookings_BookingId",
                table: "Refunds",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Bookings_BookingId",
                table: "TourBookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Promotions_PromotionId",
                table: "Tours",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "PromotionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Bookings_BookingId",
                table: "TransactionHistories",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
