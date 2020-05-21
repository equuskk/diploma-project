using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class AddBaseEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                                                         "EmploymentDate",
                                                         "AspNetUsers",
                                                         nullable: false,
                                                         oldClrType: typeof(DateTime),
                                                         oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                                                         "BirthDay",
                                                         "AspNetUsers",
                                                         nullable: false,
                                                         oldClrType: typeof(DateTime),
                                                         oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                                            "EmployeePositionId",
                                            "AspNetUsers",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.CreateTable(
                                         "EmployeePositions",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>(maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_EmployeePositions", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Expeditions",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             FromDate = table.Column<DateTimeOffset>(nullable: false),
                                             ToDate = table.Column<DateTimeOffset>(nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_Expeditions", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Litorals",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>(maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_Litorals", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "EmployeeExpedition",
                                         table => new
                                         {
                                             EmployeeId = table.Column<string>(nullable: false),
                                             ExpeditionId = table.Column<int>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_EmployeeExpedition", x => new { x.EmployeeId, x.ExpeditionId });
                                             table.ForeignKey(
                                                              "FK_EmployeeExpedition_AspNetUsers_EmployeeId",
                                                              x => x.EmployeeId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_EmployeeExpedition_Expeditions_ExpeditionId",
                                                              x => x.ExpeditionId,
                                                              "Expeditions",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "Sectors",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Square = table.Column<float>(nullable: false),
                                             LitoralId = table.Column<int>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Sectors", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_Sectors_Litorals_LitoralId",
                                                              x => x.LitoralId,
                                                              "Litorals",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "Bioresources",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Type = table.Column<string>(nullable: false),
                                             Square = table.Column<float>(nullable: false),
                                             Weight = table.Column<float>(nullable: false),
                                             SectorId = table.Column<int>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Bioresources", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_Bioresources_Sectors_SectorId",
                                                              x => x.SectorId,
                                                              "Sectors",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "ExpeditionSector",
                                         table => new
                                         {
                                             ExpeditionId = table.Column<int>(nullable: false),
                                             SectorId = table.Column<int>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_ExpeditionSector", x => new { x.ExpeditionId, x.SectorId });
                                             table.ForeignKey(
                                                              "FK_ExpeditionSector_Expeditions_ExpeditionId",
                                                              x => x.ExpeditionId,
                                                              "Expeditions",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_ExpeditionSector_Sectors_SectorId",
                                                              x => x.SectorId,
                                                              "Sectors",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUsers_EmployeePositionId",
                                         "AspNetUsers",
                                         "EmployeePositionId");

            migrationBuilder.CreateIndex(
                                         "IX_Bioresources_SectorId",
                                         "Bioresources",
                                         "SectorId");

            migrationBuilder.CreateIndex(
                                         "IX_EmployeeExpedition_ExpeditionId",
                                         "EmployeeExpedition",
                                         "ExpeditionId");

            migrationBuilder.CreateIndex(
                                         "IX_ExpeditionSector_SectorId",
                                         "ExpeditionSector",
                                         "SectorId");

            migrationBuilder.CreateIndex(
                                         "IX_Sectors_LitoralId",
                                         "Sectors",
                                         "LitoralId");

            migrationBuilder.AddForeignKey(
                                           "FK_AspNetUsers_EmployeePositions_EmployeePositionId",
                                           "AspNetUsers",
                                           "EmployeePositionId",
                                           "EmployeePositions",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_AspNetUsers_EmployeePositions_EmployeePositionId",
                                            "AspNetUsers");

            migrationBuilder.DropTable(
                                       "Bioresources");

            migrationBuilder.DropTable(
                                       "EmployeeExpedition");

            migrationBuilder.DropTable(
                                       "EmployeePositions");

            migrationBuilder.DropTable(
                                       "ExpeditionSector");

            migrationBuilder.DropTable(
                                       "Expeditions");

            migrationBuilder.DropTable(
                                       "Sectors");

            migrationBuilder.DropTable(
                                       "Litorals");

            migrationBuilder.DropIndex(
                                       "IX_AspNetUsers_EmployeePositionId",
                                       "AspNetUsers");

            migrationBuilder.DropColumn(
                                        "EmployeePositionId",
                                        "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                                                   "EmploymentDate",
                                                   "AspNetUsers",
                                                   "timestamp without time zone",
                                                   nullable: false,
                                                   oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                                                   "BirthDay",
                                                   "AspNetUsers",
                                                   "timestamp without time zone",
                                                   nullable: false,
                                                   oldClrType: typeof(DateTimeOffset));
        }
    }
}