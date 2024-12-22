using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Migrations
{
    /// <inheritdoc />
    public partial class UserChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationUser");

            migrationBuilder.DropTable(
                name: "Users_Destination");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Destinations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserID1",
                table: "Destinations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_UserID",
                table: "Destinations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_UserID1",
                table: "Destinations",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Users_UserID",
                table: "Destinations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Users_UserID1",
                table: "Destinations",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Users_UserID",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Users_UserID1",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_UserID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_UserID1",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Destinations");

            migrationBuilder.CreateTable(
                name: "DestinationUser",
                columns: table => new
                {
                    Travel_HistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Visitor_HistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationUser", x => new { x.Travel_HistoryID, x.Visitor_HistoryID });
                    table.ForeignKey(
                        name: "FK_DestinationUser_Destinations_Travel_HistoryID",
                        column: x => x.Travel_HistoryID,
                        principalTable: "Destinations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationUser_Users_Visitor_HistoryID",
                        column: x => x.Visitor_HistoryID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Destination",
                columns: table => new
                {
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Destination_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    Visited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Destination", x => new { x.User_ID, x.Destination_ID });
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationUser_Visitor_HistoryID",
                table: "DestinationUser",
                column: "Visitor_HistoryID");
        }
    }
}
