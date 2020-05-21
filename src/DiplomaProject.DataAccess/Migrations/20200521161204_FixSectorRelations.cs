using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class FixSectorRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                                       "IX_Sectors_LitoralId",
                                       "Sectors");

            migrationBuilder.CreateIndex(
                                         "IX_Sectors_LitoralId",
                                         "Sectors",
                                         "LitoralId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                                       "IX_Sectors_LitoralId",
                                       "Sectors");

            migrationBuilder.CreateIndex(
                                         "IX_Sectors_LitoralId",
                                         "Sectors",
                                         "LitoralId",
                                         unique: true);
        }
    }
}