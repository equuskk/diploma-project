using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class AddTitleToSeaweed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                                               "Title",
                                               "Seaweeds",
                                               maxLength: 100,
                                               nullable: false,
                                               defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "Title",
                                        "Seaweeds");
        }
    }
}