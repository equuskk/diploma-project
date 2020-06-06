using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class AddTitleToStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                                               "Title",
                                               "Stations",
                                               nullable: false,
                                               defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "Title",
                                        "Stations");
        }
    }
}