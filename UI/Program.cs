using Application.Contract;
using Application.Services.Guests;
using Application.Services.MealPlansRate;
using Application.Services.MeanPlans;
using Application.Services.Reservations;
using Application.Services.RoomsRate;
using Application.Services.RoomTypes;
using Application.Services.Seasons;
using Context;
using Context.DataSeeding;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Guests;
using Models.MealPlans;
using Models.Reservation;
using Models.Room;
using Models.Seasons;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var Configuration = builder.Configuration;
            builder.Services.AddDbContext<HotelDbContext>
                (option => option.UseSqlServer(Configuration.GetConnectionString("connstr")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IRepository<Guest>, Repository<Guest>>();
            builder.Services.AddScoped<IGuestServices, GuestServices>();

            builder.Services.AddScoped<IRepository<RoomType>, Repository<RoomType>>();
            builder.Services.AddScoped<IRoomsTypesServices, RoomsTypesServices>();

            builder.Services.AddScoped<IRepository<MealPlan>, Repository<MealPlan>>();
            builder.Services.AddScoped<IMealPlanServices, MealPlanServices>();

            builder.Services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
            builder.Services.AddScoped<IReservationsServices, ReservationsServices>();

            builder.Services.AddScoped<IRepositorySeason, SeasonRepository>();
            builder.Services.AddScoped<ISeasonServices, SeasonServices>();

            builder.Services.AddScoped<IRepositoryRoomRate, RoomRateRepository>();
            builder.Services.AddScoped<IRoomRateServices, RoomRateServices>();

            builder.Services.AddScoped<IRepositoryMealPlanRate, MealPlanRateRepository>();
            builder.Services.AddScoped<IMealPlanRateServices, MealPlanRateServices>();

            var app = builder.Build();

            //Date Seeding//
            var Scope = app.Services.CreateScope();
            var services = Scope.ServiceProvider;
            var dbContext = services.GetRequiredService<HotelDbContext>();

            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbContext.Database.MigrateAsync();
                await DataSeedContext.DataSeedingAsync(dbContext);
            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "Error in Migration");
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
