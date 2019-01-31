using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlustMVC.Data.Migrations
{
    public partial class ResponseStudentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_AspNetUsers_StudentId1",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_StudentId1",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Response");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Response",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Response_StudentId",
                table: "Response",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_AspNetUsers_StudentId",
                table: "Response",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_AspNetUsers_StudentId",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_StudentId",
                table: "Response");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Response",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "Response",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Response_StudentId1",
                table: "Response",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_AspNetUsers_StudentId1",
                table: "Response",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
