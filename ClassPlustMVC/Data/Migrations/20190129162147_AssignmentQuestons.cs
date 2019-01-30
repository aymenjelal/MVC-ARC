using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlustMVC.Data.Migrations
{
    public partial class AssignmentQuestons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Assignment",
                newName: "Topic");

            migrationBuilder.AddColumn<byte[]>(
                name: "Question",
                table: "Assignment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "Assignment");

            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "Assignment",
                newName: "Description");
        }
    }
}
