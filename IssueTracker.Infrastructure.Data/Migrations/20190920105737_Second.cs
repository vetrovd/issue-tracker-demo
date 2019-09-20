using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Infrastructure.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description_Value",
                table: "Issue",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Value",
                table: "Issue",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_Value",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "Name_Value",
                table: "Issue");
        }
    }
}
