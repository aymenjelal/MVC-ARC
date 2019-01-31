using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlustMVC.Data.Migrations
{
    public partial class QuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_StudentId",
                table: "Question",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_StudentId",
                table: "Question",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_StudentId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_StudentId",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_ApplicationUserId",
                table: "Question",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
