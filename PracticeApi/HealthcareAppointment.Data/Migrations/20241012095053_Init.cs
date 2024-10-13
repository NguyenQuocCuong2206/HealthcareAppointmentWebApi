using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthcareAppointment.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "Name", "Password", "Role", "Specialization" },
                values: new object[,]
                {
                    { new Guid("52de789c-6155-420e-ad0a-a0e4fd055d6f"), new DateOnly(1975, 3, 1), "drsmith@gmail.com", "Dr. Smith", "password", 0, "Cardiology" },
                    { new Guid("6f5b8cd3-1ac7-4825-a472-dce165de3ee8"), new DateOnly(1980, 4, 1), "drbrown@gmail.com", "Dr. Brown", "password", 0, "Neurology" },
                    { new Guid("a78a6edf-5126-415c-bb85-5068325ad848"), new DateOnly(1985, 2, 1), "janedoe@gmail.com", "Jane Doe", "password", 1, "" },
                    { new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"), new DateOnly(1980, 1, 1), "johndoe@gmail.com", "John Doe", "password", 1, "" },
                    { new Guid("bd352e82-edc4-4f3f-bc27-f183d8e3fdcf"), new DateOnly(1985, 5, 1), "dradams@gmail.com", "Dr. Adams", "password", 0, "Pediatrics" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "Status" },
                values: new object[,]
                {
                    { new Guid("0bae4774-f889-410d-b3e4-9feef14c67d7"), new DateTime(2024, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f5b8cd3-1ac7-4825-a472-dce165de3ee8"), new Guid("a78a6edf-5126-415c-bb85-5068325ad848"), 3 },
                    { new Guid("214d71c2-bf06-4597-82ad-1cd8b43cad18"), new DateTime(2024, 10, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f5b8cd3-1ac7-4825-a472-dce165de3ee8"), new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"), 2 },
                    { new Guid("39276b54-2b79-4322-b261-4ef733e3089d"), new DateTime(2024, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd352e82-edc4-4f3f-bc27-f183d8e3fdcf"), new Guid("a78a6edf-5126-415c-bb85-5068325ad848"), 1 },
                    { new Guid("8994847f-592a-404b-810f-35e9cd453a94"), new DateTime(2024, 10, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("52de789c-6155-420e-ad0a-a0e4fd055d6f"), new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"), 1 },
                    { new Guid("c91a0f9e-e569-4749-ab52-d3d74f7792f7"), new DateTime(2024, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd352e82-edc4-4f3f-bc27-f183d8e3fdcf"), new Guid("b3eb445a-e851-42f0-a2e1-2fe8b77df65e"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
