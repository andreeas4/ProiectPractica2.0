using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class ProiectModif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponsabilProiectId",
                table: "Proiecte",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proiecte_ResponsabilProiectId",
                table: "Proiecte",
                column: "ResponsabilProiectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proiecte_AspNetUsers_ResponsabilProiectId",
                table: "Proiecte",
                column: "ResponsabilProiectId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proiecte_AspNetUsers_ResponsabilProiectId",
                table: "Proiecte");

            migrationBuilder.DropIndex(
                name: "IX_Proiecte_ResponsabilProiectId",
                table: "Proiecte");

            migrationBuilder.DropColumn(
                name: "ResponsabilProiectId",
                table: "Proiecte");
        }
    }
}
