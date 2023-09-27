﻿// <auto-generated />
using System;
using ClassLibrary.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(PatramDbContext))]
    partial class PatramDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ClassLibrary.Models.CarrierBranchCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CarrierBranchName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Parameters")
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("CarrierBranchCategories");
                });

            modelBuilder.Entity("ClassLibrary.Models.ConsignorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConsignorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Consignors");
                });

            modelBuilder.Entity("ClassLibrary.Models.CustomerPickUpBranchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("CardPayment")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CarrierBranchCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CarrierBranchId")
                        .HasColumnType("longtext");

                    b.Property<int?>("CarrierId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerPickUpBranchName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerPickUpBranchName2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsExists")
                        .HasColumnType("tinyint(1)");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("point");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Photo")
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarrierBranchCategoryId");

                    b.HasIndex("CarrierId");

                    b.ToTable("CustomerPickUpBranches");
                });

            modelBuilder.Entity("ClassLibrary.Models.HandoverPointModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HandoverPointName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("HandoverPoint");
                });

            modelBuilder.Entity("ClassLibrary.Models.SelectabilityStatusModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("SelectabilityStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SelectabilityStatus");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            SelectabilityStatus = "HIDE"
                        },
                        new
                        {
                            Id = 1,
                            SelectabilityStatus = "DISABLED"
                        },
                        new
                        {
                            Id = 2,
                            SelectabilityStatus = "ENABLED"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.TransportServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CarrierBranchCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("ConsignorId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerFacingName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("HandoverPointDestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("HandoverPointSourceId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("PreviousTransportServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousTransportsServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("SelectabilityStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierBranchCategoryId");

                    b.HasIndex("CarrierId");

                    b.HasIndex("ConsignorId");

                    b.HasIndex("HandoverPointDestinationId");

                    b.HasIndex("HandoverPointSourceId");

                    b.HasIndex("PreviousTransportsServiceId");

                    b.HasIndex("SelectabilityStatusId");

                    b.ToTable("TransportServices");
                });

            modelBuilder.Entity("ClassLibrary.Models.WorkHoursModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CustomerPickUpBranchModelId")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TimeFrom")
                        .HasColumnType("longtext");

                    b.Property<string>("TimeTo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerPickUpBranchModelId");

                    b.ToTable("WorkHours");
                });

            modelBuilder.Entity("Library.Models.CarrierModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SelectabilityStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SelectabilityStatusId");

                    b.ToTable("Carriers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "VIVANTIS",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Česká pošta",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "PPL",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Uloženka",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "GLS",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Pošta bez hranic",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "In Time",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "Cargus",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "DHL",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Name = "Slovenská pošta",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 11,
                            IsDeleted = false,
                            Name = "DPD PickUp",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 12,
                            IsDeleted = false,
                            Name = "DPD",
                            SelectabilityStatusId = 2
                        },
                        new
                        {
                            Id = 13,
                            IsDeleted = false,
                            Name = "Zásilkovna",
                            SelectabilityStatusId = 2
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.CarrierBranchCategoryModel", b =>
                {
                    b.HasOne("Library.Models.CarrierModel", "Carrier")
                        .WithMany("CarrierBranchCategory")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("ClassLibrary.Models.CustomerPickUpBranchModel", b =>
                {
                    b.HasOne("ClassLibrary.Models.CarrierBranchCategoryModel", "CarrierBranchCategory")
                        .WithMany("CustomerPickUpBranch")
                        .HasForeignKey("CarrierBranchCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.CarrierModel", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId");

                    b.Navigation("Carrier");

                    b.Navigation("CarrierBranchCategory");
                });

            modelBuilder.Entity("ClassLibrary.Models.TransportServiceModel", b =>
                {
                    b.HasOne("ClassLibrary.Models.CarrierBranchCategoryModel", "CarrierBranchCategory")
                        .WithMany("TransportServices")
                        .HasForeignKey("CarrierBranchCategoryId");

                    b.HasOne("Library.Models.CarrierModel", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.ConsignorModel", "Consignor")
                        .WithMany()
                        .HasForeignKey("ConsignorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.HandoverPointModel", "HandoverPointDestination")
                        .WithMany("TransportServicesWithDeliveryDestination")
                        .HasForeignKey("HandoverPointDestinationId");

                    b.HasOne("ClassLibrary.Models.HandoverPointModel", "HandoverPointSource")
                        .WithMany("TransportServicesWithDeliverySource")
                        .HasForeignKey("HandoverPointSourceId");

                    b.HasOne("ClassLibrary.Models.TransportServiceModel", "PreviousTransportsService")
                        .WithMany()
                        .HasForeignKey("PreviousTransportsServiceId");

                    b.HasOne("ClassLibrary.Models.SelectabilityStatusModel", "SelectabilityStatus")
                        .WithMany()
                        .HasForeignKey("SelectabilityStatusId");

                    b.Navigation("Carrier");

                    b.Navigation("CarrierBranchCategory");

                    b.Navigation("Consignor");

                    b.Navigation("HandoverPointDestination");

                    b.Navigation("HandoverPointSource");

                    b.Navigation("PreviousTransportsService");

                    b.Navigation("SelectabilityStatus");
                });

            modelBuilder.Entity("ClassLibrary.Models.WorkHoursModel", b =>
                {
                    b.HasOne("ClassLibrary.Models.CustomerPickUpBranchModel", null)
                        .WithMany("WorkHours")
                        .HasForeignKey("CustomerPickUpBranchModelId");
                });

            modelBuilder.Entity("Library.Models.CarrierModel", b =>
                {
                    b.HasOne("ClassLibrary.Models.SelectabilityStatusModel", "SelectabilityStatus")
                        .WithMany()
                        .HasForeignKey("SelectabilityStatusId");

                    b.Navigation("SelectabilityStatus");
                });

            modelBuilder.Entity("ClassLibrary.Models.CarrierBranchCategoryModel", b =>
                {
                    b.Navigation("CustomerPickUpBranch");

                    b.Navigation("TransportServices");
                });

            modelBuilder.Entity("ClassLibrary.Models.CustomerPickUpBranchModel", b =>
                {
                    b.Navigation("WorkHours");
                });

            modelBuilder.Entity("ClassLibrary.Models.HandoverPointModel", b =>
                {
                    b.Navigation("TransportServicesWithDeliveryDestination");

                    b.Navigation("TransportServicesWithDeliverySource");
                });

            modelBuilder.Entity("Library.Models.CarrierModel", b =>
                {
                    b.Navigation("CarrierBranchCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
