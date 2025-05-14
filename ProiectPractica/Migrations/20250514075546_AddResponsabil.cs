using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsabil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResponsabiliProiecte_Cod",
                table: "ResponsabiliProiecte");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabiliProiecte_Cod",
                table: "ResponsabiliProiecte",
                column: "Cod",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResponsabiliProiecte_Cod",
                table: "ResponsabiliProiecte");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabiliProiecte_Cod",
                table: "ResponsabiliProiecte",
                column: "Cod");
        }
    }
}
