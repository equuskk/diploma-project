using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class AddSectorIdToStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_Stations_Thickets_ThicketId",
                                            "Stations");

            migrationBuilder.DropIndex(
                                       "IX_Stations_ThicketId",
                                       "Stations");

            migrationBuilder.DropColumn(
                                        "ThicketId",
                                        "Stations");

            migrationBuilder.AddColumn<int>(
                                            "SectorId",
                                            "Stations",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.CreateIndex(
                                         "IX_Stations_SectorId",
                                         "Stations",
                                         "SectorId");

            migrationBuilder.AddForeignKey(
                                           "FK_Stations_Sectors_SectorId",
                                           "Stations",
                                           "SectorId",
                                           "Sectors",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_Stations_Sectors_SectorId",
                                            "Stations");

            migrationBuilder.DropIndex(
                                       "IX_Stations_SectorId",
                                       "Stations");

            migrationBuilder.DropColumn(
                                        "SectorId",
                                        "Stations");

            migrationBuilder.AddColumn<int>(
                                            "ThicketId",
                                            "Stations",
                                            "integer",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.CreateIndex(
                                         "IX_Stations_ThicketId",
                                         "Stations",
                                         "ThicketId");

            migrationBuilder.AddForeignKey(
                                           "FK_Stations_Thickets_ThicketId",
                                           "Stations",
                                           "ThicketId",
                                           "Thickets",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);
        }
    }
}