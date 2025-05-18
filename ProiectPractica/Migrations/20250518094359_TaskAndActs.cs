using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class TaskAndActs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsabil",
                table: "Taskuri");

            migrationBuilder.AddColumn<string>(
                name: "ResponsabilId",
                table: "Taskuri",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Taskuri_ResponsabilId",
                table: "Taskuri",
                column: "ResponsabilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taskuri_AspNetUsers_ResponsabilId",
                table: "Taskuri",
                column: "ResponsabilId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taskuri_AspNetUsers_ResponsabilId",
                table: "Taskuri");

            migrationBuilder.DropIndex(
                name: "IX_Taskuri_ResponsabilId",
                table: "Taskuri");

            migrationBuilder.DropColumn(
                name: "ResponsabilId",
                table: "Taskuri");

            migrationBuilder.AddColumn<string>(
                name: "Responsabil",
                table: "Taskuri",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
