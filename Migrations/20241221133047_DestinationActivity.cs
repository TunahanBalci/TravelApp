using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Migrations
{
    /// <inheritdoc />
    public partial class DestinationActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Destinations_DestinationID",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DestinationID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "DestinationActivity",
                columns: table => new
                {
                    ActivitiesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationActivity", x => new { x.ActivitiesID, x.DestinationsID });
                    table.ForeignKey(
                        name: "FK_DestinationActivity_Activities_ActivitiesID",
                        column: x => x.ActivitiesID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationActivity_Destinations_DestinationsID",
                        column: x => x.DestinationsID,
                        principalTable: "Destinations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationActivity_DestinationsID",
                table: "DestinationActivity",
                column: "DestinationsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationActivity");

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationID",
                table: "Activities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DestinationID",
                table: "Activities",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Destinations_DestinationID",
                table: "Activities",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
