using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomDb_patientDb_PatientId",
                table: "roomDb");

            migrationBuilder.DropTable(
                name: "DrugsListDb");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "roomDb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_roomDb_patientDb_PatientId",
                table: "roomDb",
                column: "PatientId",
                principalTable: "patientDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomDb_patientDb_PatientId",
                table: "roomDb");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "roomDb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DrugsListDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugsListDb", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_roomDb_patientDb_PatientId",
                table: "roomDb",
                column: "PatientId",
                principalTable: "patientDb",
                principalColumn: "Id");
        }
    }
}
