﻿// <auto-generated />
using CS321_W3D1_BookAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS321_W3D1_BookAPI.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20200128025852_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CS321_W3D1_BookAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Catagory")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J.R.R Tolkein",
                            Catagory = "Fantasy",
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 2,
                            Author = "J.K. Rowling",
                            Catagory = "Fantasy",
                            Title = "Harry Potter"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
