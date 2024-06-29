using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugsListDb_recipesDb_recipeId",
                table: "DrugsListDb");

            migrationBuilder.DropIndex(
                name: "IX_DrugsListDb_recipeId",
                table: "DrugsListDb");

            migrationBuilder.DropColumn(
                name: "recipeId",
                table: "DrugsListDb");

            migrationBuilder.AddColumn<string>(
                name: "drugs",
                table: "recipesDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "drugs",
                table: "recipesDb");

            migrationBuilder.AddColumn<int>(
                name: "recipeId",
                table: "DrugsListDb",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrugsListDb_recipeId",
                table: "DrugsListDb",
                column: "recipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugsListDb_recipesDb_recipeId",
                table: "DrugsListDb",
                column: "recipeId",
                principalTable: "recipesDb",
                principalColumn: "Id");
        }
    }
}
