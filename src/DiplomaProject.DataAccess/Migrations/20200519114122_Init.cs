using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DiplomaProject.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                         "AspNetRoles",
                                         table => new
                                         {
                                             Id = table.Column<string>(nullable: false),
                                             Name = table.Column<string>(maxLength: 256, nullable: true),
                                             NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                                             ConcurrencyStamp = table.Column<string>(nullable: true)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

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
                                             FromDate = table.Column<DateTime>(nullable: false),
                                             ToDate = table.Column<DateTime>(nullable: false)
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
                                         "AspNetRoleClaims",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             RoleId = table.Column<string>(nullable: false),
                                             ClaimType = table.Column<string>(nullable: true),
                                             ClaimValue = table.Column<string>(nullable: true)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                                                              x => x.RoleId,
                                                              "AspNetRoles",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUsers",
                                         table => new
                                         {
                                             Id = table.Column<string>(nullable: false),
                                             UserName = table.Column<string>(maxLength: 256, nullable: true),
                                             NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                                             Email = table.Column<string>(maxLength: 256, nullable: true),
                                             NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                                             EmailConfirmed = table.Column<bool>(nullable: false),
                                             PasswordHash = table.Column<string>(nullable: true),
                                             SecurityStamp = table.Column<string>(nullable: true),
                                             ConcurrencyStamp = table.Column<string>(nullable: true),
                                             PhoneNumber = table.Column<string>(nullable: true),
                                             PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                                             TwoFactorEnabled = table.Column<bool>(nullable: false),
                                             LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                                             LockoutEnabled = table.Column<bool>(nullable: false),
                                             AccessFailedCount = table.Column<int>(nullable: false),
                                             FirstName = table.Column<string>(nullable: true),
                                             LastName = table.Column<string>(nullable: true),
                                             MidName = table.Column<string>(nullable: true),
                                             Sex = table.Column<int>(nullable: false),
                                             BirthDay = table.Column<DateTime>(nullable: false),
                                             EmployeePositionId = table.Column<int>(nullable: false),
                                             EmploymentDate = table.Column<DateTime>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_AspNetUsers_EmployeePositions_EmployeePositionId",
                                                              x => x.EmployeePositionId,
                                                              "EmployeePositions",
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
                                         "AspNetUserClaims",
                                         table => new
                                         {
                                             Id = table.Column<int>(nullable: false)
                                                       .Annotation("Npgsql:ValueGenerationStrategy",
                                                                   NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                             UserId = table.Column<string>(nullable: false),
                                             ClaimType = table.Column<string>(nullable: true),
                                             ClaimValue = table.Column<string>(nullable: true)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                                             table.ForeignKey(
                                                              "FK_AspNetUserClaims_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUserLogins",
                                         table => new
                                         {
                                             LoginProvider = table.Column<string>(nullable: false),
                                             ProviderKey = table.Column<string>(nullable: false),
                                             ProviderDisplayName = table.Column<string>(nullable: true),
                                             UserId = table.Column<string>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                                             table.ForeignKey(
                                                              "FK_AspNetUserLogins_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUserRoles",
                                         table => new
                                         {
                                             UserId = table.Column<string>(nullable: false),
                                             RoleId = table.Column<string>(nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                                             table.ForeignKey(
                                                              "FK_AspNetUserRoles_AspNetRoles_RoleId",
                                                              x => x.RoleId,
                                                              "AspNetRoles",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(
                                                              "FK_AspNetUserRoles_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(
                                         "AspNetUserTokens",
                                         table => new
                                         {
                                             UserId = table.Column<string>(nullable: false),
                                             LoginProvider = table.Column<string>(nullable: false),
                                             Name = table.Column<string>(nullable: false),
                                             Value = table.Column<string>(nullable: true)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                                             table.ForeignKey(
                                                              "FK_AspNetUserTokens_AspNetUsers_UserId",
                                                              x => x.UserId,
                                                              "AspNetUsers",
                                                              "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

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
                                         "IX_AspNetRoleClaims_RoleId",
                                         "AspNetRoleClaims",
                                         "RoleId");

            migrationBuilder.CreateIndex(
                                         "RoleNameIndex",
                                         "AspNetRoles",
                                         "NormalizedName",
                                         unique: true);

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUserClaims_UserId",
                                         "AspNetUserClaims",
                                         "UserId");

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUserLogins_UserId",
                                         "AspNetUserLogins",
                                         "UserId");

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUserRoles_RoleId",
                                         "AspNetUserRoles",
                                         "RoleId");

            migrationBuilder.CreateIndex(
                                         "IX_AspNetUsers_EmployeePositionId",
                                         "AspNetUsers",
                                         "EmployeePositionId");

            migrationBuilder.CreateIndex(
                                         "EmailIndex",
                                         "AspNetUsers",
                                         "NormalizedEmail");

            migrationBuilder.CreateIndex(
                                         "UserNameIndex",
                                         "AspNetUsers",
                                         "NormalizedUserName",
                                         unique: true);

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
                                         "LitoralId",
                                         unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "AspNetRoleClaims");

            migrationBuilder.DropTable(
                                       "AspNetUserClaims");

            migrationBuilder.DropTable(
                                       "AspNetUserLogins");

            migrationBuilder.DropTable(
                                       "AspNetUserRoles");

            migrationBuilder.DropTable(
                                       "AspNetUserTokens");

            migrationBuilder.DropTable(
                                       "Bioresources");

            migrationBuilder.DropTable(
                                       "EmployeeExpedition");

            migrationBuilder.DropTable(
                                       "ExpeditionSector");

            migrationBuilder.DropTable(
                                       "AspNetRoles");

            migrationBuilder.DropTable(
                                       "AspNetUsers");

            migrationBuilder.DropTable(
                                       "Expeditions");

            migrationBuilder.DropTable(
                                       "Sectors");

            migrationBuilder.DropTable(
                                       "EmployeePositions");

            migrationBuilder.DropTable(
                                       "Litorals");
        }
    }
}