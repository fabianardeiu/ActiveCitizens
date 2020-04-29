using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ActiveCitizens.Core.Migrations
{
    public partial class AddedNewMarkerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Markers",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "MarkerId",
                table: "Markers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Markers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Markers",
                table: "Markers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Markers",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Markers");

            migrationBuilder.AddColumn<Guid>(
                name: "MarkerId",
                table: "Markers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Markers",
                table: "Markers",
                column: "MarkerId");
        }
    }
}
