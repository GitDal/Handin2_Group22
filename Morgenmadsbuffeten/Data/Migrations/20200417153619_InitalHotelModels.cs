using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffeten.Data.Migrations
{
    public partial class InitalHotelModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckedIns",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    NumberOfAdults = table.Column<int>(nullable: false),
                    NumberOfChildren = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckedIns", x => new { x.RoomNumber, x.Date });
                });

            migrationBuilder.CreateTable(
                name: "ExpectedGuests",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    TotalAmount = table.Column<int>(nullable: false),
                    NumberOfAdults = table.Column<int>(nullable: false),
                    NumberOfChildren = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpectedGuests", x => x.Date);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckedIns");

            migrationBuilder.DropTable(
                name: "ExpectedGuests");
        }
    }
}
