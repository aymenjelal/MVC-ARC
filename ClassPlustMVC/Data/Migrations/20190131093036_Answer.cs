using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlustMVC.Data.Migrations
{
    public partial class Answer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_AspNetUsers_ApplicationUserId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_ApplicationUserId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Answer");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_StudentId",
                table: "Answer",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_AspNetUsers_StudentId",
                table: "Answer",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_AspNetUsers_StudentId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_StudentId",
                table: "Answer");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Answer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_ApplicationUserId",
                table: "Answer",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_AspNetUsers_ApplicationUserId",
                table: "Answer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
