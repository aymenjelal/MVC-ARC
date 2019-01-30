using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlustMVC.Data.Migrations
{
    public partial class AssignmentPostType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "postType",
                table: "Assignment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "postType",
                table: "Assignment");
        }
    }
}
