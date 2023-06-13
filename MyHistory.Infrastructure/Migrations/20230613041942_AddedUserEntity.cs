using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHistory.Infrastructure.Migrations
{
    public partial class AddedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                schema: "History",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "History",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "History",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                schema: "History",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                schema: "History",
                table: "Appointments",
                column: "UserId",
                principalSchema: "History",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                schema: "History",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "History");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId",
                schema: "History",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IdUser",
                schema: "History",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "History",
                table: "Appointments");
        }
    }
}
