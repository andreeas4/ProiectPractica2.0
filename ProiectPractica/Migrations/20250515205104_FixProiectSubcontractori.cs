using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class FixProiectSubcontractori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcontractori_Proiecte_ProiectEntityCod",
                table: "Subcontractori");

            migrationBuilder.DropIndex(
                name: "IX_Subcontractori_ProiectEntityCod",
                table: "Subcontractori");

            migrationBuilder.DropColumn(
                name: "ProiectEntityCod",
                table: "Subcontractori");

            migrationBuilder.CreateTable(
                name: "ProiectSubcontractori",
                columns: table => new
                {
                    ProiecteCod = table.Column<int>(type: "int", nullable: false),
                    SubcontractoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProiectSubcontractori", x => new { x.ProiecteCod, x.SubcontractoriId });
                    table.ForeignKey(
                        name: "FK_ProiectSubcontractori_Proiecte_ProiecteCod",
                        column: x => x.ProiecteCod,
                        principalTable: "Proiecte",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProiectSubcontractori_Subcontractori_SubcontractoriId",
                        column: x => x.SubcontractoriId,
                        principalTable: "Subcontractori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProiectSubcontractori_SubcontractoriId",
                table: "ProiectSubcontractori",
                column: "SubcontractoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProiectSubcontractori");

            migrationBuilder.AddColumn<int>(
                name: "ProiectEntityCod",
                table: "Subcontractori",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcontractori_ProiectEntityCod",
                table: "Subcontractori",
                column: "ProiectEntityCod");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcontractori_Proiecte_ProiectEntityCod",
                table: "Subcontractori",
                column: "ProiectEntityCod",
                principalTable: "Proiecte",
                principalColumn: "Cod");
        }
    }
}
