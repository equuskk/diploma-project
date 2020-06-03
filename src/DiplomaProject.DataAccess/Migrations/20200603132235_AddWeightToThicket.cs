using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class AddWeightToThicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "AvgWeight",
                                        "Seaweeds");

            migrationBuilder.AddColumn<float>(
                                              "WeightPerMeter",
                                              "Thickets",
                                              nullable: false,
                                              defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "WeightPerMeter",
                                        "Thickets");

            migrationBuilder.AddColumn<float>(
                                              "AvgWeight",
                                              "Seaweeds",
                                              "real",
                                              nullable: false,
                                              defaultValue: 0f);
        }
    }
}