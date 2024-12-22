using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Migrations
{
    /// <inheritdoc />
    public partial class reviewUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDestination_Activities_ActivitiesID",
                table: "ActivityDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDestination_Destinations_DestinationsID",
                table: "ActivityDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Accommodations_AccommodationID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Activities_ActivityID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Destinations_DestinationID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityDestination",
                table: "ActivityDestination");

            migrationBuilder.DropColumn(
                name: "Entity_ID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Entity_Type",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "ActivityDestination",
                newName: "ActivityDestinations");

            migrationBuilder.RenameColumn(
                name: "DestinationsID",
                table: "ActivityDestinations",
                newName: "DestinationID");

            migrationBuilder.RenameColumn(
                name: "ActivitiesID",
                table: "ActivityDestinations",
                newName: "ActivityID");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityDestination_DestinationsID",
                table: "ActivityDestinations",
                newName: "IX_ActivityDestinations_DestinationID");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityDestinations",
                table: "ActivityDestinations",
                columns: new[] { "ActivityID", "DestinationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityDestinations_Activities_ActivityID",
                table: "ActivityDestinations",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityDestinations_Destinations_DestinationID",
                table: "ActivityDestinations",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Accommodations_AccommodationID",
                table: "Reviews",
                column: "AccommodationID",
                principalTable: "Accommodations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Activities_ActivityID",
                table: "Reviews",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Destinations_DestinationID",
                table: "Reviews",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDestinations_Activities_ActivityID",
                table: "ActivityDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDestinations_Destinations_DestinationID",
                table: "ActivityDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Accommodations_AccommodationID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Activities_ActivityID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Destinations_DestinationID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityDestinations",
                table: "ActivityDestinations");

            migrationBuilder.RenameTable(
                name: "ActivityDestinations",
                newName: "ActivityDestination");

            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "ActivityDestination",
                newName: "DestinationsID");

            migrationBuilder.RenameColumn(
                name: "ActivityID",
                table: "ActivityDestination",
                newName: "ActivitiesID");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityDestinations_DestinationID",
                table: "ActivityDestination",
                newName: "IX_ActivityDestination_DestinationsID");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Entity_ID",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Entity_Type",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Accommodations_AccommodationID",
                table: "Reviews",
                column: "AccommodationID",
                principalTable: "Accommodations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Activities_ActivityID",
                table: "Reviews",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Destinations_DestinationID",
                table: "Reviews",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "ID");
        }
    }
}
