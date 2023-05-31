﻿// <auto-generated />
using AdigunAndCoPayRollSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdigunAndCoPayRollSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230530184811_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.CadreLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CadreLevel");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CadreLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CadreLevelId")
                        .IsUnique();

                    b.HasIndex("PositionId")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.PayrollComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PayrollComponent");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.PayrollComponentAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CadreLevelId")
                        .HasColumnType("int");

                    b.Property<int>("PayrollComponentId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CadreLevelId")
                        .IsUnique();

                    b.HasIndex("PayrollComponentId")
                        .IsUnique();

                    b.HasIndex("PositionId")
                        .IsUnique();

                    b.ToTable("PayrollComponentAssignment");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.PayrollStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CadreLevelId")
                        .HasColumnType("int");

                    b.Property<string>("DeductionComponentIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EarningComponentIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CadreLevelId")
                        .IsUnique();

                    b.HasIndex("PositionId")
                        .IsUnique();

                    b.ToTable("PayrollStructure");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CadreLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CadreLevelId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.Employee", b =>
                {
                    b.HasOne("AdigunAndCoPayRollSystem.Models.CadreLevel", "CadreLevel")
                        .WithOne("Employee")
                        .HasForeignKey("AdigunAndCoPayRollSystem.Models.Employee", "CadreLevelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AdigunAndCoPayRollSystem.Models.Position", "Position")
                        .WithOne("Employee")
                        .HasForeignKey("AdigunAndCoPayRollSystem.Models.Employee", "PositionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CadreLevel");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.PayrollComponentAssignment", b =>
                {
                    b.HasOne("AdigunAndCoPayRollSystem.Models.CadreLevel", "CadreLevel")
                        .WithOne("PayrollComponentAssignment")
                        .HasForeignKey("AdigunAndCoPayRollSystem.Models.PayrollComponentAssignment", "CadreLevelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AdigunAndCoPayRollSystem.Models.PayrollComponent", "PayrollComponent")
                        .WithOne("PayrollComponentAssignment")
                        .HasForeignKey("AdigunAndCoPayRollSystem.Models.PayrollComponentAssignment", "PayrollComponentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AdigunAndCoPayRollSystem.Models.Position", "Position")
                        .WithOne("PayrollComponentAssignment")
                        .HasForeignKey("AdigunAndCoPayRollSystem.Models.PayrollComponentAssignment", "PositionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CadreLevel");

                    b.Navigation("PayrollComponent");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.PayrollStructure", b =>
                {
                    b.HasOne("AdigunAndCoPayRollSystem.Models.CadreLevel", "CadreLevel")
                        .WithOne("PayrollStructure")
                        .HasForeignKey("AdigunAndCoPayRollSystem.Models.PayrollStructure", "CadreLevelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AdigunAndCoPayRollSystem.Models.Position", "Position")
                        .WithOne("PayrollStructure")
                        .HasForeignKey("AdigunAndCoPayRollSystem.Models.PayrollStructure", "PositionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CadreLevel");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.Position", b =>
                {
                    b.HasOne("AdigunAndCoPayRollSystem.Models.CadreLevel", "CadreLevel")
                        .WithMany()
                        .HasForeignKey("CadreLevelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CadreLevel");
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.CadreLevel", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("PayrollComponentAssignment")
                        .IsRequired();

                    b.Navigation("PayrollStructure")
                        .IsRequired();
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.PayrollComponent", b =>
                {
                    b.Navigation("PayrollComponentAssignment")
                        .IsRequired();
                });

            modelBuilder.Entity("AdigunAndCoPayRollSystem.Models.Position", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("PayrollComponentAssignment")
                        .IsRequired();

                    b.Navigation("PayrollStructure")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
