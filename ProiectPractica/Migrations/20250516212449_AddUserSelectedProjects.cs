using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSelectedProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserSelectedProjects",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProiectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelectedProjects", x => new { x.UserId, x.ProiectId });
                    table.ForeignKey(
                        name: "FK_UserSelectedProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSelectedProjects_Proiecte_ProiectId",
                        column: x => x.ProiectId,
                        principalTable: "Proiecte",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSelectedProjects_ProiectId",
                table: "UserSelectedProjects",
                column: "ProiectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSelectedProjects");

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
    }
}
