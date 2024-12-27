﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApp.Data;

#nullable disable

namespace TravelApp.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241227002759_bookingFunc")]
    partial class bookingFunc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccommodationActivity", b =>
                {
                    b.Property<Guid>("AccommodationsID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivitiesID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccommodationsID", "ActivitiesID");

                    b.HasIndex("ActivitiesID");

                    b.ToTable("AccommodationActivity");
                });

            modelBuilder.Entity("AccommodationAmenity", b =>
                {
                    b.Property<Guid>("AccommodationsID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AmenitiesID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccommodationsID", "AmenitiesID");

                    b.HasIndex("AmenitiesID");

                    b.ToTable("AccommodationAmenity");
                });

            modelBuilder.Entity("ActivityDestination", b =>
                {
                    b.Property<Guid>("ActivityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DestinationID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActivityID", "DestinationID");

                    b.HasIndex("DestinationID");

                    b.ToTable("ActivityDestinations", (string)null);
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Accommodation", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<double?>("Average_Rating")
                        .HasColumnType("float");

                    b.Property<Guid>("CityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.HasIndex("UserID");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Activity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Average_Rating")
                        .HasColumnType("float");

                    b.Property<Guid?>("CityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Requires_Reservation")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Amenity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Booking", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccommodationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Booking_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AccommodationID");

                    b.HasIndex("UserID");

                    b.ToTable("Booking", t =>
                        {
                            t.HasCheckConstraint("CK_Booking_StartBeforeEnd", "Start_Date < Start_Date");
                        });
                });

            modelBuilder.Entity("TravelApp.Models.Entities.City", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Cost_Of_Living")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Terrain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Destination", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Average_Rating")
                        .HasColumnType("float");

                    b.Property<Guid>("CityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Image_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.HasIndex("UserID");

                    b.HasIndex("UserID1");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Preference", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("DestinationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("Content")
                        .IsUnique();

                    b.HasIndex("DestinationID");

                    b.HasIndex("UserID");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Review", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccommodationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActivityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("DestinationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AccommodationID");

                    b.HasIndex("ActivityID");

                    b.HasIndex("DestinationID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Visit", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DestinationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Visit_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID", "DestinationID");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("AccommodationActivity", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.Accommodation", null)
                        .WithMany()
                        .HasForeignKey("AccommodationsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.Entities.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("AccommodationAmenity", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.Accommodation", null)
                        .WithMany()
                        .HasForeignKey("AccommodationsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.Entities.Amenity", null)
                        .WithMany()
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ActivityDestination", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.Entities.Destination", null)
                        .WithMany()
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Accommodation", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.City", "City")
                        .WithMany("Accommodations")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.Entities.User", null)
                        .WithMany("Booking_History")
                        .HasForeignKey("UserID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Activity", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.City", null)
                        .WithMany("Activities")
                        .HasForeignKey("CityID");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Booking", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.Accommodation", "Accommodation")
                        .WithMany("Bookings")
                        .HasForeignKey("AccommodationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Destination", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.City", "City")
                        .WithMany("Destinations")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.Entities.User", null)
                        .WithMany("Favorited")
                        .HasForeignKey("UserID");

                    b.HasOne("TravelApp.Models.Entities.User", null)
                        .WithMany("Visited")
                        .HasForeignKey("UserID1");

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Preference", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.Destination", null)
                        .WithMany("Attractions")
                        .HasForeignKey("DestinationID");

                    b.HasOne("TravelApp.Models.Entities.User", null)
                        .WithMany("Preferences")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Review", b =>
                {
                    b.HasOne("TravelApp.Models.Entities.Accommodation", "Accommodation")
                        .WithMany("Reviews")
                        .HasForeignKey("AccommodationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TravelApp.Models.Entities.Activity", "Activity")
                        .WithMany("Reviews")
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TravelApp.Models.Entities.Destination", "Destination")
                        .WithMany("Reviews")
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TravelApp.Models.Entities.User", "User")
                        .WithMany("Review_History")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Activity");

                    b.Navigation("Destination");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Accommodation", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Activity", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.City", b =>
                {
                    b.Navigation("Accommodations");

                    b.Navigation("Activities");

                    b.Navigation("Destinations");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.Destination", b =>
                {
                    b.Navigation("Attractions");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TravelApp.Models.Entities.User", b =>
                {
                    b.Navigation("Booking_History");

                    b.Navigation("Favorited");

                    b.Navigation("Preferences");

                    b.Navigation("Review_History");

                    b.Navigation("Visited");
                });
#pragma warning restore 612, 618
        }
    }
}