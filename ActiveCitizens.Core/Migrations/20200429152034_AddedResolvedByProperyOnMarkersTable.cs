using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ActiveCitizens.Core.Migrations
{
    public partial class AddedResolvedByProperyOnMarkersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Citizens_CitizenId",
                table: "Markers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Markers",
                table: "Markers");

            migrationBuilder.DropIndex(
                name: "IX_Markers_CitizenId",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "Markers");

            migrationBuilder.AddColumn<Guid>(
                name: "MarkerId",
                table: "Markers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByCitizenId",
                table: "Markers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResolvedByCitizenId",
                table: "Markers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Markers",
                table: "Markers",
                column: "MarkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Markers_CreatedByCitizenId",
                table: "Markers",
                column: "CreatedByCitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Markers_ResolvedByCitizenId",
                table: "Markers",
                column: "ResolvedByCitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Citizens_CreatedByCitizenId",
                table: "Markers",
                column: "CreatedByCitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Citizens_ResolvedByCitizenId",
                table: "Markers",
                column: "ResolvedByCitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Citizens_CreatedByCitizenId",
                table: "Markers");

            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Citizens_ResolvedByCitizenId",
                table: "Markers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Markers",
                table: "Markers");

            migrationBuilder.DropIndex(
                name: "IX_Markers_CreatedByCitizenId",
                table: "Markers");

            migrationBuilder.DropIndex(
                name: "IX_Markers_ResolvedByCitizenId",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "MarkerId",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "CreatedByCitizenId",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "ResolvedByCitizenId",
                table: "Markers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Markers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CitizenId",
                table: "Markers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Markers",
                table: "Markers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Markers_CitizenId",
                table: "Markers",
                column: "CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Citizens_CitizenId",
                table: "Markers",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
