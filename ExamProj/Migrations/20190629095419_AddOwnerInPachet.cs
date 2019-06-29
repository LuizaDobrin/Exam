using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamProj.Migrations
{
    public partial class AddOwnerInPachet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Pachete",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pachete_OwnerId",
                table: "Pachete",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pachete_Users_OwnerId",
                table: "Pachete",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pachete_Users_OwnerId",
                table: "Pachete");

            migrationBuilder.DropIndex(
                name: "IX_Pachete_OwnerId",
                table: "Pachete");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Pachete");
        }
    }
}
