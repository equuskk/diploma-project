using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class AddNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_Sectors_Litorals_LitoralId",
                                            "Sectors");

            migrationBuilder.DropForeignKey(
                                            "FK_Stations_GroundTypes_GroundTypeId",
                                            "Stations");

            migrationBuilder.DropForeignKey(
                                            "FK_Stations_Litorals_LitoralId",
                                            "Stations");

            migrationBuilder.DropForeignKey(
                                            "FK_Stations_Sectors_SectorId",
                                            "Stations");

            migrationBuilder.DropForeignKey(
                                            "FK_Stations_ThicketTypes_ThicketTypeId",
                                            "Stations");

            migrationBuilder.DropTable(
                                       "Bioresources");

            migrationBuilder.DropTable(
                                       "ThicketTypes");

            migrationBuilder.DropIndex(
                                       "IX_Stations_GroundTypeId",
                                       "Stations");

            migrationBuilder.DropIndex(
                                       "IX_Stations_LitoralId",
                                       "Stations");

            migrationBuilder.DropIndex(
                                       "IX_Stations_SectorId",
                                       "Stations");

            migrationBuilder.DropIndex(
                                       "IX_Stations_ThicketTypeId",
                                       "Stations");

            migrationBuilder.DropIndex(
                                       "IX_Sectors_LitoralId",
                                       "Sectors");

            migrationBuilder.DropColumn(
                                        "GroundTypeId",
                                        "Stations");

            migrationBuilder.DropColumn(
                                        "LitoralId",
                                        "Stations");

            migrationBuilder.DropColumn(
                                        "PrimingId",
                                        "Stations");

            migrationBuilder.DropColumn(
                                        "SectorId",
                                        "Stations");

            migrationBuilder.DropColumn(
                                        "ThicketTypeId",
                                        "Stations");

            migrationBuilder.DropColumn(
                                        "LitoralId",
                                        "Sectors");

            migrationBuilder.DropColumn(
                                        "Location",
                                        "Sectors");

            migrationBuilder.AddColumn<int>(
                                            "ThicketId",
                                            "Stations",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                                               "Description",
                                               "Sectors",
                                               maxLength: 500,
                                               nullable: false,
                                               defaultValue: "");

            migrationBuilder.CreateTable(
                                         "SeaweedCategories",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>(maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_SeaweedCategories", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "SeaweedTypes",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>(maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_SeaweedTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Seaweeds",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             AvgWeight = table.Column<float>(nullable: false),
                                             SeaweedTypeId = table.Column<int>(nullable: false),
                                             SeaweedCategoryId = table.Column<int>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Seaweeds", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_Seaweeds_SeaweedCategories_SeaweedCategoryId",
                                                              x => x.SeaweedCategoryId,
                                                              "SeaweedCategories",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Seaweeds_SeaweedTypes_SeaweedTypeId",
                                                              x => x.SeaweedTypeId,
                                                              "SeaweedTypes",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "Thickets",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Location = table.Column<Point>("geography", nullable: false),
                                             Date = table.Column<DateTimeOffset>(nullable: false),
                                             Length = table.Column<float>(nullable: false),
                                             Width = table.Column<float>(nullable: false),
                                             Stock = table.Column<float>(nullable: false),
                                             LitoralId = table.Column<int>(nullable: false),
                                             GroundTypeId = table.Column<int>(nullable: false),
                                             SeaweedId = table.Column<int>(nullable: false),
                                             SectorId = table.Column<int>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Thickets", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_Thickets_GroundTypes_GroundTypeId",
                                                              x => x.GroundTypeId,
                                                              "GroundTypes",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Thickets_Litorals_LitoralId",
                                                              x => x.LitoralId,
                                                              "Litorals",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Thickets_Seaweeds_SeaweedId",
                                                              x => x.SeaweedId,
                                                              "Seaweeds",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_Thickets_Sectors_SectorId",
                                                              x => x.SectorId,
                                                              "Sectors",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateIndex(
                                         "IX_Stations_ThicketId",
                                         "Stations",
                                         "ThicketId");

            migrationBuilder.CreateIndex(
                                         "IX_Seaweeds_SeaweedCategoryId",
                                         "Seaweeds",
                                         "SeaweedCategoryId");

            migrationBuilder.CreateIndex(
                                         "IX_Seaweeds_SeaweedTypeId",
                                         "Seaweeds",
                                         "SeaweedTypeId");

            migrationBuilder.CreateIndex(
                                         "IX_Thickets_GroundTypeId",
                                         "Thickets",
                                         "GroundTypeId");

            migrationBuilder.CreateIndex(
                                         "IX_Thickets_LitoralId",
                                         "Thickets",
                                         "LitoralId");

            migrationBuilder.CreateIndex(
                                         "IX_Thickets_SeaweedId",
                                         "Thickets",
                                         "SeaweedId");

            migrationBuilder.CreateIndex(
                                         "IX_Thickets_SectorId",
                                         "Thickets",
                                         "SectorId");

            migrationBuilder.AddForeignKey(
                                           "FK_Stations_Thickets_ThicketId",
                                           "Stations",
                                           "ThicketId",
                                           "Thickets",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_Stations_Thickets_ThicketId",
                                            "Stations");

            migrationBuilder.DropTable(
                                       "Thickets");

            migrationBuilder.DropTable(
                                       "Seaweeds");

            migrationBuilder.DropTable(
                                       "SeaweedCategories");

            migrationBuilder.DropTable(
                                       "SeaweedTypes");

            migrationBuilder.DropIndex(
                                       "IX_Stations_ThicketId",
                                       "Stations");

            migrationBuilder.DropColumn(
                                        "ThicketId",
                                        "Stations");

            migrationBuilder.DropColumn(
                                        "Description",
                                        "Sectors");

            migrationBuilder.AddColumn<int>(
                                            "GroundTypeId",
                                            "Stations",
                                            "integer",
                                            nullable: true);

            migrationBuilder.AddColumn<int>(
                                            "LitoralId",
                                            "Stations",
                                            "integer",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                                            "PrimingId",
                                            "Stations",
                                            "integer",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                                            "SectorId",
                                            "Stations",
                                            "integer",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                                            "ThicketTypeId",
                                            "Stations",
                                            "integer",
                                            nullable: false,
                                            defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                                            "LitoralId",
                                            "Sectors",
                                            "integer",
                                            nullable: true);

            migrationBuilder.AddColumn<Polygon>(
                                                "Location",
                                                "Sectors",
                                                "geography",
                                                nullable: false);

            migrationBuilder.CreateTable(
                                         "Bioresources",
                                         table => new
                                         {
                                             Id = table.Column<int>("integer", nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             SectorId = table.Column<int>("integer", nullable: false),
                                             Type = table.Column<string>("text", nullable: false),
                                             Weight = table.Column<float>("real", nullable: false)
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
                                         "ThicketTypes",
                                         table => new
                                         {
                                             Id = table.Column<int>("integer", nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             Title = table.Column<string>("character varying(100)", maxLength: 100, nullable: false)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_ThicketTypes", x => x.Id); });

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
                                         "IX_Sectors_LitoralId",
                                         "Sectors",
                                         "LitoralId");

            migrationBuilder.CreateIndex(
                                         "IX_Bioresources_SectorId",
                                         "Bioresources",
                                         "SectorId");

            migrationBuilder.AddForeignKey(
                                           "FK_Sectors_Litorals_LitoralId",
                                           "Sectors",
                                           "LitoralId",
                                           "Litorals",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                                           "FK_Stations_GroundTypes_GroundTypeId",
                                           "Stations",
                                           "GroundTypeId",
                                           "GroundTypes",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                                           "FK_Stations_Litorals_LitoralId",
                                           "Stations",
                                           "LitoralId",
                                           "Litorals",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_Stations_Sectors_SectorId",
                                           "Stations",
                                           "SectorId",
                                           "Sectors",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                                           "FK_Stations_ThicketTypes_ThicketTypeId",
                                           "Stations",
                                           "ThicketTypeId",
                                           "ThicketTypes",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);
        }
    }
}