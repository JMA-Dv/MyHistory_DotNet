using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHistory.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "History");

            migrationBuilder.CreateTable(
                name: "Medications",
                schema: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presentation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                schema: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSpecialist = table.Column<int>(type: "int", nullable: false),
                    SpecialistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalSchema: "History",
                        principalTable: "Specialists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                schema: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSpecialist = table.Column<int>(type: "int", nullable: false),
                    SpecialistId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalSchema: "History",
                        principalTable: "Specialists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentMedication",
                schema: "History",
                columns: table => new
                {
                    AppointmentsId = table.Column<int>(type: "int", nullable: false),
                    MedicationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentMedication", x => new { x.AppointmentsId, x.MedicationsId });
                    table.ForeignKey(
                        name: "FK_AppointmentMedication_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalSchema: "History",
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentMedication_Medications_MedicationsId",
                        column: x => x.MedicationsId,
                        principalSchema: "History",
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationAppointments",
                schema: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedication = table.Column<int>(type: "int", nullable: false),
                    MedicationId = table.Column<int>(type: "int", nullable: true),
                    IdAppointment = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    PrescriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationDays = table.Column<int>(type: "int", nullable: false),
                    DoseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "History",
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationAppointments_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalSchema: "History",
                        principalTable: "Medications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                schema: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAppointment = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "History",
                        principalTable: "Appointments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentMedication_MedicationsId",
                schema: "History",
                table: "AppointmentMedication",
                column: "MedicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SpecialistId",
                schema: "History",
                table: "Appointments",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationAppointments_AppointmentId",
                schema: "History",
                table: "MedicationAppointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationAppointments_MedicationId",
                schema: "History",
                table: "MedicationAppointments",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_SpecialistId",
                schema: "History",
                table: "Specialties",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AppointmentId",
                schema: "History",
                table: "Tests",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentMedication",
                schema: "History");

            migrationBuilder.DropTable(
                name: "MedicationAppointments",
                schema: "History");

            migrationBuilder.DropTable(
                name: "Specialties",
                schema: "History");

            migrationBuilder.DropTable(
                name: "Tests",
                schema: "History");

            migrationBuilder.DropTable(
                name: "Medications",
                schema: "History");

            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "History");

            migrationBuilder.DropTable(
                name: "Specialists",
                schema: "History");
        }
    }
}
