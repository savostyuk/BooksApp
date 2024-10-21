﻿// <auto-generated />
using System;
using BooksApp.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookPublisher", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "PublisherId");

                    b.HasIndex("PublisherId");

                    b.ToTable("PublisherBooks", (string)null);
                });

            modelBuilder.Entity("BooksApp.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("BooksApp.Domain.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Belarus",
                            Email = "ad_press@gmail.com",
                            Name = "Ad Press"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Poland",
                            Email = "academic_studies@gmail.com",
                            Name = "Academic Studies"
                        });
                });

            modelBuilder.Entity("BooksApp.Domain.Entities.EducationalBook", b =>
                {
                    b.HasBaseType("BooksApp.Domain.Entities.Book");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("EducationalBooks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Author = "Natalya Shulzhenka",
                            Name = "C# for adults",
                            Year = 2015,
                            Level = "Adults",
                            Speciality = "Programming"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Mister Bean",
                            Name = "How to learn",
                            Year = 2005,
                            Level = "Children",
                            Speciality = "Psycology"
                        });
                });

            modelBuilder.Entity("BooksApp.Domain.Entities.FictionBook", b =>
                {
                    b.HasBaseType("BooksApp.Domain.Entities.Book");

                    b.Property<int?>("AgeRestrictions")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FictionBooks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Joanne Rowling",
                            Name = "Harry Potter",
                            Year = 2000,
                            AgeRestrictions = 6,
                            Genre = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Author = "John Ronald Reuel Tolkien",
                            Name = "The Lord of the Rings",
                            Year = 2010,
                            AgeRestrictions = 18,
                            Genre = "Mystery"
                        });
                });

            modelBuilder.Entity("BookPublisher", b =>
                {
                    b.HasOne("BooksApp.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksApp.Domain.Entities.Publisher", null)
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BooksApp.Domain.Entities.EducationalBook", b =>
                {
                    b.HasOne("BooksApp.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BooksApp.Domain.Entities.FictionBook", b =>
                {
                    b.HasOne("BooksApp.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
