﻿// <auto-generated />
using System;
using FuelAccounting.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuelAccounting.Context.Migrations
{
    [DbContext(typeof(FuelAccountingContext))]
    partial class FuelAccountingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DriversLicense")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("DriversLicense")
                        .IsUnique()
                        .HasDatabaseName("IX_Driver_DriversLicense")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("Drivers", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Fuel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Count")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FuelType")
                        .HasDatabaseName("IX_Fuel_FuelType")
                        .HasFilter("DeletedAt is null");

                    b.HasIndex("SupplierId");

                    b.ToTable("Fuels", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.FuelAccountingItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Count")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FuelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FuelStationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("TrailerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TruckId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("FuelId");

                    b.HasIndex("FuelStationId");

                    b.HasIndex("TrailerId");

                    b.HasIndex("TruckId");

                    b.HasIndex("StartDate", "EndDate")
                        .HasDatabaseName("IX_FuelAccountingItem_StartDate_EndDate")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("FuelAccountingItems", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.FuelStation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique()
                        .HasDatabaseName("IX_FuelStation_Address")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("FuelStations", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Inn")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Inn")
                        .IsUnique()
                        .HasDatabaseName("IX_Supplier_Inn")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Trailer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique()
                        .HasDatabaseName("IX_Trailer_Number")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("Trailers", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Truck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Vin")
                        .IsUnique()
                        .HasDatabaseName("IX_Truck_Vin")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("Trucks", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasDatabaseName("IX_User_Login")
                        .HasFilter("DeletedAt is null");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Fuel", b =>
                {
                    b.HasOne("FuelAccounting.Context.Contracts.Models.Supplier", "Supplier")
                        .WithMany("Fuel")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.FuelAccountingItem", b =>
                {
                    b.HasOne("FuelAccounting.Context.Contracts.Models.Driver", "Driver")
                        .WithMany("FuelAccountingItem")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuelAccounting.Context.Contracts.Models.Fuel", "Fuel")
                        .WithMany("FuelAccountingItem")
                        .HasForeignKey("FuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuelAccounting.Context.Contracts.Models.FuelStation", "FuelStation")
                        .WithMany("FuelAccountingItem")
                        .HasForeignKey("FuelStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuelAccounting.Context.Contracts.Models.Trailer", "Trailer")
                        .WithMany("FuelAccountingItem")
                        .HasForeignKey("TrailerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuelAccounting.Context.Contracts.Models.Truck", "Truck")
                        .WithMany("FuelAccountingItem")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Fuel");

                    b.Navigation("FuelStation");

                    b.Navigation("Trailer");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Driver", b =>
                {
                    b.Navigation("FuelAccountingItem");
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Fuel", b =>
                {
                    b.Navigation("FuelAccountingItem");
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.FuelStation", b =>
                {
                    b.Navigation("FuelAccountingItem");
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Supplier", b =>
                {
                    b.Navigation("Fuel");
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Trailer", b =>
                {
                    b.Navigation("FuelAccountingItem");
                });

            modelBuilder.Entity("FuelAccounting.Context.Contracts.Models.Truck", b =>
                {
                    b.Navigation("FuelAccountingItem");
                });
#pragma warning restore 612, 618
        }
    }
}
