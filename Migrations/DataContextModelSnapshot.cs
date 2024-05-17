﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrometoFoodTrucksBackEnds.Services.Context;

#nullable disable

namespace PrometoFoodTrucksBackEnds.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schedule")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TruckInfos");
                });

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel+MenuItem", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemId"));

                    b.Property<int>("FoodTrucksID")
                        .HasColumnType("int");

                    b.Property<int?>("FoodTrucksIteamsModelID")
                        .HasColumnType("int");

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemPrice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itemId");

                    b.HasIndex("FoodTrucksIteamsModelID");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.UserModel", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schedule")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.UserModel+MenuItem", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemId"));

                    b.Property<int>("FoodTrucksID")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelUserID")
                        .HasColumnType("int");

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemPrice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itemId");

                    b.HasIndex("UserModelUserID");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel+MenuItem", b =>
                {
                    b.HasOne("PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel", null)
                        .WithMany("menuItems")
                        .HasForeignKey("FoodTrucksIteamsModelID");
                });

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.UserModel+MenuItem", b =>
                {
                    b.HasOne("PrometoFoodTrucksBackEnds.Models.UserModel", null)
                        .WithMany("menuItems")
                        .HasForeignKey("UserModelUserID");
                });

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel", b =>
                {
                    b.Navigation("menuItems");
                });

            modelBuilder.Entity("PrometoFoodTrucksBackEnds.Models.UserModel", b =>
                {
                    b.Navigation("menuItems");
                });
#pragma warning restore 612, 618
        }
    }
}
