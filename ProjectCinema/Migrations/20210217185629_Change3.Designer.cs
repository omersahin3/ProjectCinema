﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectCinema.Data.Models;

namespace ProjectCinema.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210217185629_Change3")]
    partial class Change3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectCinema.Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CivilPrice")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Director")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MovieName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("StudentPrice")
                        .HasColumnType("float");

                    b.Property<string>("Time")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.MovieCategory", b =>
                {
                    b.Property<int>("MovieCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.HasKey("MovieCategoryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieCategory");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.Saloon", b =>
                {
                    b.Property<int>("SaloonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColumnArmChairNumber")
                        .HasColumnType("int");

                    b.Property<int>("LineArmChairNumber")
                        .HasColumnType("int");

                    b.Property<string>("SaloonName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SaloonID");

                    b.ToTable("Saloons");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.Session", b =>
                {
                    b.Property<int>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int>("SaloonID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SessionID");

                    b.HasIndex("MovieID");

                    b.HasIndex("SaloonID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.MovieCategory", b =>
                {
                    b.HasOne("ProjectCinema.Data.Models.Category", "Category")
                        .WithMany("MovieCategory")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectCinema.Data.Models.Movie", "Movie")
                        .WithMany("MovieCategory")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.Session", b =>
                {
                    b.HasOne("ProjectCinema.Data.Models.Movie", "Movie")
                        .WithMany("Session")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectCinema.Data.Models.Saloon", "Saloon")
                        .WithMany("Session")
                        .HasForeignKey("SaloonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Saloon");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.Category", b =>
                {
                    b.Navigation("MovieCategory");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.Movie", b =>
                {
                    b.Navigation("MovieCategory");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("ProjectCinema.Data.Models.Saloon", b =>
                {
                    b.Navigation("Session");
                });
#pragma warning restore 612, 618
        }
    }
}
