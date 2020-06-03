﻿// <auto-generated />
using System;
using DiplomaProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DiplomaProject.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200603132235_AddWeightToThicket")]
    partial class AddWeightToThicket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:postgis", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("EmploymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MidName")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.EmployeeExpedition", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("text");

                    b.Property<int>("ExpeditionId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId", "ExpeditionId");

                    b.HasIndex("ExpeditionId");

                    b.ToTable("EmployeeExpeditions");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Expedition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("ToDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Expeditions");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.ExpeditionSector", b =>
                {
                    b.Property<int>("ExpeditionId")
                        .HasColumnType("integer");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer");

                    b.HasKey("ExpeditionId", "SectorId");

                    b.HasIndex("SectorId");

                    b.ToTable("ExpeditionSectors");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.GroundType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("GroundTypes");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Litoral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Litorals");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Seaweed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("SeaweedCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("SeaweedTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("SeaweedCategoryId");

                    b.HasIndex("SeaweedTypeId");

                    b.ToTable("Seaweeds");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.SeaweedCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("SeaweedCategories");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.SeaweedType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("SeaweedTypes");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<int>("ThicketId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ThicketId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.StationData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Density")
                        .HasColumnType("real");

                    b.Property<float>("Depth")
                        .HasColumnType("real");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("StationsData");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Thicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GroundTypeId")
                        .HasColumnType("integer");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("LitoralId")
                        .HasColumnType("integer");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<int>("SeaweedId")
                        .HasColumnType("integer");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer");

                    b.Property<float>("Stock")
                        .HasColumnType("real");

                    b.Property<float>("WeightPerMeter")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GroundTypeId");

                    b.HasIndex("LitoralId");

                    b.HasIndex("SeaweedId");

                    b.HasIndex("SectorId");

                    b.ToTable("Thickets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.EmployeeExpedition", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.Employee", "Employee")
                        .WithMany("Expeditions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Domain.Entities.Expedition", "Expedition")
                        .WithMany("Employees")
                        .HasForeignKey("ExpeditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.ExpeditionSector", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.Expedition", "Expedition")
                        .WithMany("Sectors")
                        .HasForeignKey("ExpeditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Domain.Entities.Sector", "Sector")
                        .WithMany("Expeditions")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Seaweed", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.SeaweedCategory", "Category")
                        .WithMany()
                        .HasForeignKey("SeaweedCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Domain.Entities.SeaweedType", "Type")
                        .WithMany()
                        .HasForeignKey("SeaweedTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Station", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.Thicket", "Thicket")
                        .WithMany()
                        .HasForeignKey("ThicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.StationData", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.Station", "Station")
                        .WithMany("StationData")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiplomaProject.Domain.Entities.Thicket", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.GroundType", "GroundType")
                        .WithMany()
                        .HasForeignKey("GroundTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Domain.Entities.Litoral", "Litoral")
                        .WithMany()
                        .HasForeignKey("LitoralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Domain.Entities.Seaweed", "Seaweed")
                        .WithMany()
                        .HasForeignKey("SeaweedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Domain.Entities.Sector", "Sector")
                        .WithMany("Thickets")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomaProject.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DiplomaProject.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
