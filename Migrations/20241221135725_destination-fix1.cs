using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Migrations
{
    /// <inheritdoc />
    public partial class destinationfix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationActivity_Activities_ActivitiesID",
                table: "DestinationActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationActivity_Destinations_DestinationsID",
                table: "DestinationActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinationActivity",
                table: "DestinationActivity");

            migrationBuilder.RenameTable(
                name: "DestinationActivity",
                newName: "ActivityDestination");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationActivity_DestinationsID",
                table: "ActivityDestination",
                newName: "IX_ActivityDestination_DestinationsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityDestination",
                table: "ActivityDestination",
                columns: new[] { "ActivitiesID", "DestinationsID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityDestination_Activities_ActivitiesID",
                table: "ActivityDestination",
                column: "ActivitiesID",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityDestination_Destinations_DestinationsID",
                table: "ActivityDestination",
                column: "DestinationsID",
                principalTable: "Destinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDestination_Activities_ActivitiesID",
                table: "ActivityDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDestination_Destinations_DestinationsID",
                table: "ActivityDestination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityDestination",
                table: "ActivityDestination");

            migrationBuilder.RenameTable(
                name: "ActivityDestination",
                newName: "DestinationActivity");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityDestination_DestinationsID",
                table: "DestinationActivity",
                newName: "IX_DestinationActivity_DestinationsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinationActivity",
                table: "DestinationActivity",
                columns: new[] { "ActivitiesID", "DestinationsID" });

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationActivity_Activities_ActivitiesID",
                table: "DestinationActivity",
                column: "ActivitiesID",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationActivity_Destinations_DestinationsID",
                table: "DestinationActivity",
                column: "DestinationsID",
                principalTable: "Destinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
