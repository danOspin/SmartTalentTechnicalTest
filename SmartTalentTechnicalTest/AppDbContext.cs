using Microsoft.EntityFrameworkCore;

namespace SmartTalentTechnicalTest
{
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<EmailNotification> EmailNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique constraint on Email for Users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Default values for Hotel and Room
            modelBuilder.Entity<Hotel>()
                .Property(h => h.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Room>()
                .Property(r => r.IsActive)
                .HasDefaultValue(true);

            // Define relationships
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelID);

            modelBuilder.Entity<Reservation>()
                .HasOne(res => res.Room)
                .WithMany()
                .HasForeignKey(res => res.RoomID);

            modelBuilder.Entity<Reservation>()
                .HasOne(res => res.User)
                .WithMany()
                .HasForeignKey(res => res.UserID);

            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Reservation)
                .WithMany(res => res.Guests)
                .HasForeignKey(g => g.ReservationID);

            modelBuilder.Entity<EmailNotification>()
                .HasOne(en => en.Reservation)
                .WithMany()
                .HasForeignKey(en => en.ReservationID);

            modelBuilder.Entity<EmailNotification>()
                .HasKey(e => e.NotificationID);

        }
    }

}
