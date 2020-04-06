using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ActiveCitizens.Api.Migrations
{
    public partial class AddResolvedAtColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedAt",
                table: "Markers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResolvedAt",
                table: "Markers");
        }
    }
}
