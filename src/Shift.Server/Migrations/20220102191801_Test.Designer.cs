﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shift.Server.Context;

#nullable disable

namespace Shift.Server.Migrations
{
    [DbContext(typeof(ShiftContext))]
    [Migration("20220102191801_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategorySQLShiftSQL", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShiftsId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "ShiftsId");

                    b.HasIndex("ShiftsId");

                    b.ToTable("CategorySQLShiftSQL");
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.CategorySQL", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid?>("ShiftCategorySQLId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShiftCategorySQLId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.ShiftCategorySQL", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ShiftId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ShiftCategories");
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.ShiftSQL", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("BaseMediaFilename")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MaskMediaFilename")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("MediaFilename")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<bool>("Private")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ShiftCategorySQLId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Verified")
                        .HasColumnType("boolean");

                    b.Property<int>("Views")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ShiftCategorySQLId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.UserSQL", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Admin")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanTrain")
                        .HasColumnType("boolean");

                    b.Property<bool>("Verified")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CategorySQLShiftSQL", b =>
                {
                    b.HasOne("Shift.Server.Models.SQL.CategorySQL", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shift.Server.Models.SQL.ShiftSQL", null)
                        .WithMany()
                        .HasForeignKey("ShiftsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.CategorySQL", b =>
                {
                    b.HasOne("Shift.Server.Models.SQL.ShiftCategorySQL", null)
                        .WithMany("Category")
                        .HasForeignKey("ShiftCategorySQLId");
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.ShiftSQL", b =>
                {
                    b.HasOne("Shift.Server.Models.SQL.UserSQL", "Author")
                        .WithMany("shifts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shift.Server.Models.SQL.ShiftCategorySQL", null)
                        .WithMany("Shift")
                        .HasForeignKey("ShiftCategorySQLId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.ShiftCategorySQL", b =>
                {
                    b.Navigation("Category");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Shift.Server.Models.SQL.UserSQL", b =>
                {
                    b.Navigation("shifts");
                });
#pragma warning restore 612, 618
        }
    }
}