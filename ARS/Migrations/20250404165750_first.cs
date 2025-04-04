using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARS.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Passenger_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passenger_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passenger_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passenger_DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passenger_Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Passenger_ID);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Route_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No_Of_Passenger = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Route_ID);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Flights_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flights_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flights_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flights_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flights_Duration = table.Column<int>(type: "int", nullable: false),
                    Flights_Amount = table.Column<int>(type: "int", nullable: false),
                    RouteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Flights_ID);
                    table.ForeignKey(
                        name: "FK_Flights_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "Route_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Seats_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seats_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Seats = table.Column<int>(type: "int", nullable: false),
                    Price_Per_Seat = table.Column<int>(type: "int", nullable: false),
                    Check_In_Baggage_Per_Seat = table.Column<int>(type: "int", nullable: false),
                    Flights_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Seats_ID);
                    table.ForeignKey(
                        name: "FK_Seats_Flights_Flights_ID",
                        column: x => x.Flights_ID,
                        principalTable: "Flights",
                        principalColumn: "Flights_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Bookings_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookings_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bookings_Cost = table.Column<int>(type: "int", nullable: false),
                    Flights_ID = table.Column<int>(type: "int", nullable: false),
                    Seats_ID = table.Column<int>(type: "int", nullable: false),
                    Passenger_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Bookings_ID);
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_Flights_ID",
                        column: x => x.Flights_ID,
                        principalTable: "Flights",
                        principalColumn: "Flights_ID");
                    table.ForeignKey(
                        name: "FK_Bookings_Passengers_Passenger_ID",
                        column: x => x.Passenger_ID,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID");
                    table.ForeignKey(
                        name: "FK_Bookings_Seats_Seats_ID",
                        column: x => x.Seats_ID,
                        principalTable: "Seats",
                        principalColumn: "Seats_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Flights_ID",
                table: "Bookings",
                column: "Flights_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Passenger_ID",
                table: "Bookings",
                column: "Passenger_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Seats_ID",
                table: "Bookings",
                column: "Seats_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_RouteID",
                table: "Flights",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Flights_ID",
                table: "Seats",
                column: "Flights_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
