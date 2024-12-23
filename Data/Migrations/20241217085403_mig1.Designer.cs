﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApp.Data;

#nullable disable

namespace TravelApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241217085403_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TravelApp.Models.Accommodation", b =>
                {
                    b.Property<int>("Accommodation_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Accommodation_ID"));

                    b.Property<int>("Availability")
                        .HasColumnType("int");

                    b.Property<decimal>("Average_Review")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("City_ID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Accommodation_ID");

                    b.HasIndex("City_ID");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("TravelApp.Models.AccommodationActivity", b =>
                {
                    b.Property<int>("Accommodation_ID")
                        .HasColumnType("int");

                    b.Property<int>("Activity_ID")
                        .HasColumnType("int");

                    b.HasKey("Accommodation_ID", "Activity_ID");

                    b.HasIndex("Activity_ID");

                    b.ToTable("AccommodationActivities");
                });

            modelBuilder.Entity("TravelApp.Models.Activities", b =>
                {
                    b.Property<int>("Activity_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Activity_ID"));

                    b.Property<decimal>("Average_Review")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("Destination_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("Required_Reservations")
                        .HasColumnType("bit");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Activity_ID");

                    b.HasIndex("Destination_ID");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TravelApp.Models.Booking", b =>
                {
                    b.Property<int>("Booking_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Booking_ID"));

                    b.Property<int>("Accommodation_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Booking_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Booking_ID");

                    b.HasIndex("Accommodation_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TravelApp.Models.City", b =>
                {
                    b.Property<int>("City_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("City_ID"));

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Cost_Of_Living")
                        .HasColumnType("int");

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

                    b.HasKey("City_ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TravelApp.Models.CityCommonActivity", b =>
                {
                    b.Property<int>("City_ID")
                        .HasColumnType("int");

                    b.Property<string>("Activity")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("City_ID", "Activity");

                    b.ToTable("CityCommonActivities");
                });

            modelBuilder.Entity("TravelApp.Models.Destination", b =>
                {
                    b.Property<int>("Destination_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Destination_ID"));

                    b.Property<decimal>("Average_Review")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("City_ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Destination_ID");

                    b.HasIndex("City_ID");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TravelApp.Models.DestinationAttraction", b =>
                {
                    b.Property<int>("Destination_ID")
                        .HasColumnType("int");

                    b.Property<string>("Attraction")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Destination_ID", "Attraction");

                    b.ToTable("DestinationAttractions");
                });

            modelBuilder.Entity("TravelApp.Models.Review", b =>
                {
                    b.Property<int>("Review_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Review_ID"));

                    b.Property<int>("Entity_ID")
                        .HasColumnType("int");

                    b.Property<string>("Entity_Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Review_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TravelApp.Models.ReviewComment", b =>
                {
                    b.Property<int>("Comment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Comment_ID"));

                    b.Property<DateTime>("Comment_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment_Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Review_ID")
                        .HasColumnType("int");

                    b.HasKey("Comment_ID");

                    b.HasIndex("Review_ID");

                    b.ToTable("ReviewComments");
                });

            modelBuilder.Entity("TravelApp.Models.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("User_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelApp.Models.UserDestination", b =>
                {
                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<int>("Destination_ID")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Favorite")
                        .HasColumnType("bit");

                    b.Property<bool>("Visited")
                        .HasColumnType("bit");

                    b.HasKey("User_ID", "Destination_ID");

                    b.HasIndex("Destination_ID");

                    b.ToTable("UserDestinations");
                });

            modelBuilder.Entity("TravelApp.Models.UserPreference", b =>
                {
                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<string>("Preference")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("User_ID", "Preference");

                    b.ToTable("UserPreferences");
                });

            modelBuilder.Entity("TravelApp.Models.UserTravelHistory", b =>
                {
                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<int>("Destination_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Visit_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("User_ID", "Destination_ID");

                    b.HasIndex("Destination_ID");

                    b.ToTable("UserTravelHistories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelApp.Models.Accommodation", b =>
                {
                    b.HasOne("TravelApp.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("City_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelApp.Models.AccommodationActivity", b =>
                {
                    b.HasOne("TravelApp.Models.Accommodation", "Accommodation")
                        .WithMany("AccommodationActivities")
                        .HasForeignKey("Accommodation_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.Activities", "Activity")
                        .WithMany("AccommodationActivities")
                        .HasForeignKey("Activity_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("TravelApp.Models.Activities", b =>
                {
                    b.HasOne("TravelApp.Models.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("Destination_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TravelApp.Models.Booking", b =>
                {
                    b.HasOne("TravelApp.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("Accommodation_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Models.CityCommonActivity", b =>
                {
                    b.HasOne("TravelApp.Models.City", "City")
                        .WithMany("CityCommonActivities")
                        .HasForeignKey("City_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelApp.Models.Destination", b =>
                {
                    b.HasOne("TravelApp.Models.City", "City")
                        .WithMany("Destinations")
                        .HasForeignKey("City_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelApp.Models.DestinationAttraction", b =>
                {
                    b.HasOne("TravelApp.Models.Destination", "Destination")
                        .WithMany("DestinationAttractions")
                        .HasForeignKey("Destination_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TravelApp.Models.Review", b =>
                {
                    b.HasOne("TravelApp.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Models.ReviewComment", b =>
                {
                    b.HasOne("TravelApp.Models.Review", "Review")
                        .WithMany("ReviewComments")
                        .HasForeignKey("Review_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("TravelApp.Models.UserDestination", b =>
                {
                    b.HasOne("TravelApp.Models.Destination", "Destination")
                        .WithMany("UserDestinations")
                        .HasForeignKey("Destination_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.User", "User")
                        .WithMany("UserDestinations")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Models.UserPreference", b =>
                {
                    b.HasOne("TravelApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Models.UserTravelHistory", b =>
                {
                    b.HasOne("TravelApp.Models.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("Destination_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelApp.Models.Accommodation", b =>
                {
                    b.Navigation("AccommodationActivities");
                });

            modelBuilder.Entity("TravelApp.Models.Activities", b =>
                {
                    b.Navigation("AccommodationActivities");
                });

            modelBuilder.Entity("TravelApp.Models.City", b =>
                {
                    b.Navigation("CityCommonActivities");

                    b.Navigation("Destinations");
                });

            modelBuilder.Entity("TravelApp.Models.Destination", b =>
                {
                    b.Navigation("DestinationAttractions");

                    b.Navigation("UserDestinations");
                });

            modelBuilder.Entity("TravelApp.Models.Review", b =>
                {
                    b.Navigation("ReviewComments");
                });

            modelBuilder.Entity("TravelApp.Models.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");

                    b.Navigation("UserDestinations");
                });
#pragma warning restore 612, 618
        }
    }
}
