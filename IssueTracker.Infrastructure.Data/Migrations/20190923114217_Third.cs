using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Infrastructure.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "project_pkey",
                table: "Issue");

            migrationBuilder.AddColumn<int>(
                name: "Status_Value",
                table: "Issue",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issue",
                table: "Issue",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Issue",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "Status_Value",
                table: "Issue");

            migrationBuilder.AddPrimaryKey(
                name: "project_pkey",
                table: "Issue",
                column: "Id");
        }
    }
}
