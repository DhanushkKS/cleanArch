﻿// <auto-generated />
using System;
using CleanArch.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanArch.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20240108145240_CreatedTables")]
    partial class CreatedTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanArch.Domain.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MemberId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RentalId")
                        .HasColumnType("integer");

                    b.HasKey("MemberId");

                    b.HasIndex("RentalId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CleanArch.Domain.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MovieId"));

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("RentalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RentalDuration")
                        .HasColumnType("integer");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CleanArch.Domain.MovieRental", b =>
                {
                    b.Property<int>("RentalId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.HasKey("RentalId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieRentals");
                });

            modelBuilder.Entity("CleanArch.Domain.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RentalId"));

                    b.Property<decimal>("RentalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RentalExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RentalId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CleanArch.Domain.Member", b =>
                {
                    b.HasOne("CleanArch.Domain.Rental", "Rental")
                        .WithMany("Members")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("CleanArch.Domain.MovieRental", b =>
                {
                    b.HasOne("CleanArch.Domain.Movie", null)
                        .WithMany("MovieRentals")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArch.Domain.Rental", null)
                        .WithMany("MovieRentals")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArch.Domain.Movie", b =>
                {
                    b.Navigation("MovieRentals");
                });

            modelBuilder.Entity("CleanArch.Domain.Rental", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("MovieRentals");
                });
#pragma warning restore 612, 618
        }
    }
}