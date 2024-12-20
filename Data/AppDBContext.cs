using Microsoft.EntityFrameworkCore;
using TravelApp.Models.Entities;

namespace TravelApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        public DbSet<Activity> Activities { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<User_Destination> Users_Destination { get; set; }
        public DbSet<User_Travel_History> Users_Accommodation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Booking Check Constraint
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Booking_StartBeforeEnd", "Start_Date < Start_Date"); // Ensure column names match
                });
            });

            // Accommodation-Activity Many-to-Many Relationship
            modelBuilder.Entity<Accommodation>()
                .HasMany(a => a.Activities)
                .WithMany(b => b.Accommodations)
                .UsingEntity<Dictionary<string, object>>(
                    "AccommodationActivity",
                    j => j
                        .HasOne<Activity>()
                        .WithMany()
                        .HasForeignKey("ActivitiesID")
                        .OnDelete(DeleteBehavior.NoAction), // Prevent cascading deletes on Activities
                    j => j
                        .HasOne<Accommodation>()
                        .WithMany()
                        .HasForeignKey("AccommodationsID")
                        .OnDelete(DeleteBehavior.Cascade) // Allow cascading deletes on Accommodations
                );

            modelBuilder.Entity<User_Destination>()
                .HasKey(ud => new { ud.User_ID, ud.Destination_ID });
            modelBuilder.Entity<User_Travel_History>()
                .HasKey(uth => new { uth.User_ID, uth.Destination_ID });
        }
    }
}
