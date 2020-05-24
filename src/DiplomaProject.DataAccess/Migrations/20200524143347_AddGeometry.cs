using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class AddGeometry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_AspNetUsers_EmployeePositions_EmployeePositionId",
                                            "AspNetUsers");

            migrationBuilder.DropForeignKey(
                                            "FK_EmployeeExpedition_AspNetUsers_EmployeeId",
                                            "EmployeeExpedition");

            migrationBuilder.DropForeignKey(
                                            "FK_EmployeeExpedition_Expeditions_ExpeditionId",
                                            "EmployeeExpedition");

            migrationBuilder.DropForeignKey(
                                            "FK_ExpeditionSector_Expeditions_ExpeditionId",
                                            "ExpeditionSector");

            migrationBuilder.DropForeignKey(
                                            "FK_ExpeditionSector_Sectors_SectorId",
                                            "ExpeditionSector");

            migrationBuilder.DropForeignKey(
                                            "FK_Sectors_Litorals_LitoralId",
                                            "Sectors");

            migrationBuilder.DropTable(
                                       "EmployeePositions");

            migrationBuilder.DropIndex(
                                       "IX_AspNetUsers_EmployeePositionId",
                                       "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                                            "PK_ExpeditionSector",
                                            "ExpeditionSector");

            migrationBuilder.DropPrimaryKey(
                                            "PK_EmployeeExpedition",
                                            "EmployeeExpedition");

            migrationBuilder.DropColumn(
                                        "Square",
                                        "Sectors");

            migrationBuilder.DropColumn(
                                        "Square",
                                        "Bioresources");

            migrationBuilder.DropColumn(
                                        "EmployeePositionId",
                                        "AspNetUsers");

            migrationBuilder.RenameTable(
                                         "ExpeditionSector",
                                         newName: "ExpeditionSectors");

            migrationBuilder.RenameTable(
                                         "EmployeeExpedition",
                                         newName: "EmployeeExpeditions");

            migrationBuilder.RenameIndex(
                                         "IX_ExpeditionSector_SectorId",
                                         table: "ExpeditionSectors",
                                         newName: "IX_ExpeditionSectors_SectorId");

            migrationBuilder.RenameIndex(
                                         "IX_EmployeeExpedition_ExpeditionId",
                                         table: "EmployeeExpeditions",
                                         newName: "IX_EmployeeExpeditions_ExpeditionId");

            migrationBuilder.AlterDatabase()
                            .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.AlterColumn<int>(
                                              "LitoralId",
                                              "Sectors",
                                              nullable: true,
                                              oldClrType: typeof(int),
                                              oldType: "integer");

            migrationBuilder.AddColumn<Polygon>(
                                                "Location",
                                                "Sectors",
                                                "geography",
                                                nullable: false);

            migrationBuilder.AddPrimaryKey(
                                           "PK_ExpeditionSectors",
                                           "ExpeditionSectors",
                                           new[] { "ExpeditionId", "SectorId" });

            migrationBuilder.AddPrimaryKey(
                                           "PK_EmployeeExpeditions",
                                           "EmployeeExpeditions",
                                           new[] { "EmployeeId", "ExpeditionId" });

            migrationBuilder.CreateTable(
                                         "GroundTypes",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>(maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_GroundTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "ThicketTypes",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>(maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_ThicketTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Stations",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Location = table.Column<Point>("geography", nullable: true),
                                             SectorId = table.Column<int>(nullable: false),
                                             LitoralId = table.Column<int>(nullable: false),
                                             PrimingId = table.Column<int>(nullable: false),
                                             ThicketTypeId = table.Column<int>(nullable: false),
                                             GroundTypeId = table.Column<int>(nullable: true)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Stations", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_Stations_GroundTypes_GroundTypeId",
                                                              x => x.GroundTypeId,
                                                              "GroundTypes",
                                                              "Id",
                                                              onDelete: ReferentialAction.Restrict);
                                             table.ForeignKey(
                                                              "FK_Stations_Litorals_LitoralId",
                                                              x => x.LitoralId,
                                                              "Litorals",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Stations_Sectors_SectorId",
                                                              x => x.SectorId,
                                                              "Sectors",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Stations_ThicketTypes_ThicketTypeId",
                                                              x => x.ThicketTypeId,
                                                              "ThicketTypes",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "StationsData",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Date = table.Column<DateTimeOffset>(nullable: false),
                                             Temperature = table.Column<float>(nullable: false),
                                             Density = table.Column<float>(nullable: false),
                                             Depth = table.Column<float>(nullable: false),
                                             StationId = table.Column<int>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_StationsData", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_StationsData_Stations_StationId",
                                                              x => x.StationId,
                                                              "Stations",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateIndex(
                                         "IX_Stations_GroundTypeId",
                                         "Stations",
                                         "GroundTypeId");

            migrationBuilder.CreateIndex(
                                         "IX_Stations_LitoralId",
                                         "Stations",
                                         "LitoralId");

            migrationBuilder.CreateIndex(
                                         "IX_Stations_SectorId",
                                         "Stations",
                                         "SectorId");

            migrationBuilder.CreateIndex(
                                         "IX_Stations_ThicketTypeId",
                                         "Stations",
                                         "ThicketTypeId");

            migrationBuilder.CreateIndex(
                                         "IX_StationsData_StationId",
                                         "StationsData",
                                         "StationId");

            migrationBuilder.AddForeignKey(
                                           "FK_EmployeeExpeditions_AspNetUsers_EmployeeId",
                                           "EmployeeExpeditions",
                                           "EmployeeId",
                                           "AspNetUsers",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_EmployeeExpeditions_Expeditions_ExpeditionId",
                                           "EmployeeExpeditions",
                                           "ExpeditionId",
                                           "Expeditions",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_ExpeditionSectors_Expeditions_ExpeditionId",
                                           "ExpeditionSectors",
                                           "ExpeditionId",
                                           "Expeditions",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_ExpeditionSectors_Sectors_SectorId",
                                           "ExpeditionSectors",
                                           "SectorId",
                                           "Sectors",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_Sectors_Litorals_LitoralId",
                                           "Sectors",
                                           "LitoralId",
                                           "Litorals",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_EmployeeExpeditions_AspNetUsers_EmployeeId",
                                            "EmployeeExpeditions");

            migrationBuilder.DropForeignKey(
                                            "FK_EmployeeExpeditions_Expeditions_ExpeditionId",
                                            "EmployeeExpeditions");

            migrationBuilder.DropForeignKey(
                                            "FK_ExpeditionSectors_Expeditions_ExpeditionId",
                                            "ExpeditionSectors");

            migrationBuilder.DropForeignKey(
                                            "FK_ExpeditionSectors_Sectors_SectorId",
                                            "ExpeditionSectors");

            migrationBuilder.DropForeignKey(
                                            "FK_Sectors_Litorals_LitoralId",
                                            "Sectors");

            migrationBuilder.DropTable(
                                       "StationsData");

            migrationBuilder.DropTable(
                                       "Stations");

            migrationBuilder.DropTable(
                                       "GroundTypes");

            migrationBuilder.DropTable(
                                       "ThicketTypes");

            migrationBuilder.DropPrimaryKey(
                                            "PK_ExpeditionSectors",
                                            "ExpeditionSectors");

            migrationBuilder.DropPrimaryKey(
                                            "PK_EmployeeExpeditions",
                                            "EmployeeExpeditions");

            migrationBuilder.DropColumn(
                                        "Location",
                                        "Sectors");

            migrationBuilder.RenameTable(
                                         "ExpeditionSectors",
                                         newName: "ExpeditionSector");

            migrationBuilder.RenameTable(
                                         "EmployeeExpeditions",
                                         newName: "EmployeeExpedition");

            migrationBuilder.RenameIndex(
                                         "IX_ExpeditionSectors_SectorId",
                                         table: "ExpeditionSector",
                                         newName: "IX_ExpeditionSector_SectorId");

            migrationBuilder.RenameIndex(
                                         "IX_EmployeeExpeditions_ExpeditionId",
                                         table: "EmployeeExpedition",
                                         newName: "IX_EmployeeExpedition_ExpeditionId");

            migrationBuilder.AlterDatabase()
                            .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.AlterColumn<int>(
                                              "LitoralId",
                                              "Sectors",
                                              "integer",
                                              nullable: false,
                                              oldClrType: typeof(int),
                                              oldNullable: true);

            migrationBuilder.AddColumn<float>(
                                              "Square",
                                              "Sectors",
                                              "real",
                                              nullable: false,
                                              defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                                              "Square",
                                              "Bioresources",
                                              "real",
                                              nullable: false,
                                              defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                                            "EmployeePositionId",
                                            "AspNetUsers",
                                            "integer",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                                           "PK_ExpeditionSector",
                                           "ExpeditionSector",
                                           new[] { "ExpeditionId", "SectorId" });

            migrationBuilder.AddPrimaryKey(
                                           "PK_EmployeeExpedition",
                                           "EmployeeExpedition",
                                           new[] { "EmployeeId", "ExpeditionId" });

            migrationBuilder.CreateTable(
                                         "EmployeePositions",
                                         table => new
                                         {
                                             Id = table.Column<int>("integer", nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>("character varying(100)", maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_EmployeePositions", x => x.Id); });

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUsers_EmployeePositionId",
                                         "AspNetUsers",
                                         "EmployeePositionId");

            migrationBuilder.AddForeignKey(
                                           "FK_AspNetUsers_EmployeePositions_EmployeePositionId",
                                           "AspNetUsers",
                                           "EmployeePositionId",
                                           "EmployeePositions",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_EmployeeExpedition_AspNetUsers_EmployeeId",
                                           "EmployeeExpedition",
                                           "EmployeeId",
                                           "AspNetUsers",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_EmployeeExpedition_Expeditions_ExpeditionId",
                                           "EmployeeExpedition",
                                           "ExpeditionId",
                                           "Expeditions",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_ExpeditionSector_Expeditions_ExpeditionId",
                                           "ExpeditionSector",
                                           "ExpeditionId",
                                           "Expeditions",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_ExpeditionSector_Sectors_SectorId",
                                           "ExpeditionSector",
                                           "SectorId",
                                           "Sectors",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_Sectors_Litorals_LitoralId",
                                           "Sectors",
                                           "LitoralId",
                                           "Litorals",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);
        }
    }
}