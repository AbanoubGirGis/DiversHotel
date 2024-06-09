using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Models.Guests;
using Models.MealPlans;
using Models.Reservation;
using Models.Room;
using Models.Seasons;

namespace Context
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Room> room { get; set; }
        public DbSet<RoomType> roomType { get; set; }
        public DbSet<RoomRate> roomRate { get; set; }

        public DbSet<MealPlan> mealPlan { get; set; }
        public DbSet<MealPlanRate> mealPlanRate { get; set; }

        public DbSet<Season> season { get; set; }

        public DbSet<Guest> guest { get; set; }
       
        public DbSet<Reservation> reservation { get; set; }
        

        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().ToTable("Guest");
            modelBuilder.Entity<MealPlanRate>().ToTable("MealPlanRate");
            modelBuilder.Entity<MealPlan>().ToTable("MealPlan");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RoomRate>().ToTable("RoomRate");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            modelBuilder.Entity<Season>().ToTable("Season");
        }
    }
}
