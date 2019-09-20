namespace IssueTracker.Infrastructure.Data.Migrations
{
	using Microsoft.EntityFrameworkCore.Migrations;

	public partial class Second : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				"Description_Value",
				"Issue",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				"Name_Value",
				"Issue",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				"Description_Value",
				"Issue");

			migrationBuilder.DropColumn(
				"Name_Value",
				"Issue");
		}
	}
}