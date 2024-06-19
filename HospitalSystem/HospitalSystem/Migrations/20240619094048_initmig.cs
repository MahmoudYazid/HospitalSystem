using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Migrations
{
    /// <inheritdoc />
    public partial class initmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinicDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinicDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patientDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctorDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clinicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctorDb_clinicDb_clinicID",
                        column: x => x.clinicID,
                        principalTable: "clinicDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roomDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roomDb_patientDb_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patientDb",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "roomWaitingListDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomWaitingListDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roomWaitingListDb_patientDb_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patientDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointmentDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointmentDb_doctorDb_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctorDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointmentDb_patientDb_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patientDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    drugs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipesDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipesDb_doctorDb_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctorDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipesDb_patientDb_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patientDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    report = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportsDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reportsDb_doctorDb_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctorDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reportsDb_patientDb_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patientDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointmentDb_DoctorId",
                table: "appointmentDb",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_appointmentDb_PatientId",
                table: "appointmentDb",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorDb_clinicID",
                table: "doctorDb",
                column: "clinicID");

            migrationBuilder.CreateIndex(
                name: "IX_recipesDb_DoctorId",
                table: "recipesDb",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_recipesDb_PatientId",
                table: "recipesDb",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_reportsDb_DoctorId",
                table: "reportsDb",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_reportsDb_PatientId",
                table: "reportsDb",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_roomDb_PatientId",
                table: "roomDb",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_roomWaitingListDb_PatientId",
                table: "roomWaitingListDb",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointmentDb");

            migrationBuilder.DropTable(
                name: "recipesDb");

            migrationBuilder.DropTable(
                name: "reportsDb");

            migrationBuilder.DropTable(
                name: "roomDb");

            migrationBuilder.DropTable(
                name: "roomWaitingListDb");

            migrationBuilder.DropTable(
                name: "doctorDb");

            migrationBuilder.DropTable(
                name: "patientDb");

            migrationBuilder.DropTable(
                name: "clinicDb");
        }
    }
}
