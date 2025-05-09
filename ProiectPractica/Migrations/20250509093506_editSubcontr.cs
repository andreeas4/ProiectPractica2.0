using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class editSubcontr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcontractori_Proiecte_Cod",
                table: "Subcontractori");

            migrationBuilder.DropIndex(
                name: "IX_Subcontractori_Cod",
                table: "Subcontractori");

            migrationBuilder.DropColumn(
                name: "Cod",
                table: "Subcontractori");

            migrationBuilder.AddColumn<int>(
                name: "ProiectCod",
                table: "Subcontractori",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcontractori_ProiectCod",
                table: "Subcontractori",
                column: "ProiectCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcontractori_Proiecte_ProiectCod",
                table: "Subcontractori",
                column: "ProiectCod",
                principalTable: "Proiecte",
                principalColumn: "Cod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcontractori_Proiecte_ProiectCod",
                table: "Subcontractori");

            migrationBuilder.DropIndex(
                name: "IX_Subcontractori_ProiectCod",
                table: "Subcontractori");

            migrationBuilder.DropColumn(
                name: "ProiectCod",
                table: "Subcontractori");

            migrationBuilder.AddColumn<int>(
                name: "Cod",
                table: "Subcontractori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subcontractori_Cod",
                table: "Subcontractori",
                column: "Cod");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcontractori_Proiecte_Cod",
                table: "Subcontractori",
                column: "Cod",
                principalTable: "Proiecte",
                principalColumn: "Cod",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
