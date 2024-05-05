using Microsoft.EntityFrameworkCore;
using Tour_Travel.Models;

namespace Tour_Travel.Data
{
    public class TourDbContext : DbContext
    {
        public TourDbContext(DbContextOptions<TourDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourAvailability> TourAvailabilities { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }
        public DbSet<TourCancellation> TourCancellations { get; set; }
        public DbSet<TourFood> TourFoods { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }
        public DbSet<TourHotel> TourHotels { get; set; }
        public DbSet<TourImage> TourImages { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<TourTransport> TourTransports { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
