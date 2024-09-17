﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tour_Travel.Data;

#nullable disable

namespace Tour_Travel.Migrations
{
    [DbContext(typeof(TourDbContext))]
    partial class TourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tour_Travel.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Tour_Travel.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TourBookingId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("TourBookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Tour_Travel.Models.Promotion", b =>
                {
                    b.Property<int>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromotionId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RemainingUses")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PromotionId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Tour_Travel.Models.Refund", b =>
                {
                    b.Property<int>("RefundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefundId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("RefundDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourBookingId")
                        .HasColumnType("int");

                    b.HasKey("RefundId");

                    b.HasIndex("TourBookingId");

                    b.ToTable("Refunds");
                });

            modelBuilder.Entity("Tour_Travel.Models.Review", b =>
                {
                    b.Property<int>("Reviewid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reviewid"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Reviewid");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Tour_Travel.Models.Tour", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourId"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TourPackageId")
                        .HasColumnType("int");

                    b.HasKey("TourId");

                    b.HasIndex("TourPackageId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourAvailability", b =>
                {
                    b.Property<int>("TourAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourAvailabilityId"));

                    b.Property<int>("AvailableSlots")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("TourAvailabilityId");

                    b.HasIndex("TourId");

                    b.ToTable("TourAvailabilities");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourBooking", b =>
                {
                    b.Property<int>("TourBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourBookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfPersons")
                        .HasColumnType("int");

                    b.Property<int?>("PromotionId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TourBookingId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("TourId");

                    b.HasIndex("UserId");

                    b.ToTable("TourBookings");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourCancellation", b =>
                {
                    b.Property<int>("TourCancellationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourCancellationId"));

                    b.Property<DateTime>("CancellationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("TourBookingId")
                        .HasColumnType("int");

                    b.HasKey("TourCancellationId");

                    b.HasIndex("TourBookingId");

                    b.ToTable("TourCancellations");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourFood", b =>
                {
                    b.Property<int>("TourFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourFoodId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TourFoodId");

                    b.ToTable("TourFoods");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourGuide", b =>
                {
                    b.Property<int>("TourGuideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourGuideId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<decimal>("GuideFee")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TourGuideId");

                    b.ToTable("TourGuides");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourHotel", b =>
                {
                    b.Property<int>("TourHotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourHotelId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3, 2)");

                    b.HasKey("TourHotelId");

                    b.ToTable("TourHotels");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourImage", b =>
                {
                    b.Property<int>("TourImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourImageId"));

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("TourImageId");

                    b.HasIndex("TourId");

                    b.ToTable("TourImages");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourPackage", b =>
                {
                    b.Property<int>("TourPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourPackageId"));

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("TourFoodId")
                        .HasColumnType("int");

                    b.Property<string>("TourFoodIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TourGuideId")
                        .HasColumnType("int");

                    b.Property<string>("TourGuideIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TourHotelId")
                        .HasColumnType("int");

                    b.Property<string>("TourHotelIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TourTransportId")
                        .HasColumnType("int");

                    b.Property<string>("TourTransportIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TourPackageId");

                    b.HasIndex("TourFoodId");

                    b.HasIndex("TourGuideId");

                    b.HasIndex("TourHotelId");

                    b.HasIndex("TourTransportId");

                    b.ToTable("TourPackages");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourTransport", b =>
                {
                    b.Property<int>("TourTransportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourTransportId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("RentPerPerson")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TourTransportName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TourTransportId");

                    b.ToTable("TourTransports");
                });

            modelBuilder.Entity("Tour_Travel.Models.TransactionHistory", b =>
                {
                    b.Property<int>("TransactionHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionHistoryId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("TourBookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TransactionHistoryId");

                    b.HasIndex("TourBookingId");

                    b.HasIndex("UserId");

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("Tour_Travel.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tour_Travel.Models.Payment", b =>
                {
                    b.HasOne("Tour_Travel.Models.TourBooking", "TourBooking")
                        .WithMany("Payments")
                        .HasForeignKey("TourBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourBooking");
                });

            modelBuilder.Entity("Tour_Travel.Models.Refund", b =>
                {
                    b.HasOne("Tour_Travel.Models.TourBooking", "TourBooking")
                        .WithMany("Refunds")
                        .HasForeignKey("TourBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourBooking");
                });

            modelBuilder.Entity("Tour_Travel.Models.Review", b =>
                {
                    b.HasOne("Tour_Travel.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tour_Travel.Models.Tour", b =>
                {
                    b.HasOne("Tour_Travel.Models.TourPackage", "TourPackage")
                        .WithMany("Tour")
                        .HasForeignKey("TourPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourPackage");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourAvailability", b =>
                {
                    b.HasOne("Tour_Travel.Models.Tour", "Tour")
                        .WithMany("TourAvailabilities")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourBooking", b =>
                {
                    b.HasOne("Tour_Travel.Models.Promotion", "Promotion")
                        .WithMany("TourBookings")
                        .HasForeignKey("PromotionId");

                    b.HasOne("Tour_Travel.Models.Tour", "Tour")
                        .WithMany("TourBooking")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tour_Travel.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");

                    b.Navigation("Tour");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourCancellation", b =>
                {
                    b.HasOne("Tour_Travel.Models.TourBooking", "TourBooking")
                        .WithMany("TourCancellations")
                        .HasForeignKey("TourBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourBooking");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourImage", b =>
                {
                    b.HasOne("Tour_Travel.Models.Tour", "Tour")
                        .WithMany("TourImage")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourPackage", b =>
                {
                    b.HasOne("Tour_Travel.Models.TourFood", null)
                        .WithMany("Packages")
                        .HasForeignKey("TourFoodId");

                    b.HasOne("Tour_Travel.Models.TourGuide", null)
                        .WithMany("Packages")
                        .HasForeignKey("TourGuideId");

                    b.HasOne("Tour_Travel.Models.TourHotel", null)
                        .WithMany("Packages")
                        .HasForeignKey("TourHotelId");

                    b.HasOne("Tour_Travel.Models.TourTransport", null)
                        .WithMany("Packages")
                        .HasForeignKey("TourTransportId");
                });

            modelBuilder.Entity("Tour_Travel.Models.TransactionHistory", b =>
                {
                    b.HasOne("Tour_Travel.Models.TourBooking", "TourBooking")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("TourBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tour_Travel.Models.User", "User")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourBooking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tour_Travel.Models.Promotion", b =>
                {
                    b.Navigation("TourBookings");
                });

            modelBuilder.Entity("Tour_Travel.Models.Tour", b =>
                {
                    b.Navigation("TourAvailabilities");

                    b.Navigation("TourBooking");

                    b.Navigation("TourImage");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourBooking", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Refunds");

                    b.Navigation("TourCancellations");

                    b.Navigation("TransactionHistories");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourFood", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourGuide", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourHotel", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourPackage", b =>
                {
                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Tour_Travel.Models.TourTransport", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Tour_Travel.Models.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");

                    b.Navigation("TransactionHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
