using Models.MealPlans;
using Models.Room;
using Models.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Context.DataSeeding
{
    public class DataSeedContext
    {
        public static async Task DataSeedingAsync(HotelDbContext hotelDbContext)
        {
            if (!hotelDbContext.roomType.Any() &&
               !hotelDbContext.room.Any() &&
               !hotelDbContext.season.Any() &&
               !hotelDbContext.roomRate.Any() &&
               !hotelDbContext.mealPlan.Any() &&
               !hotelDbContext.mealPlanRate.Any())
            {
                // Input Room Type Data
                var RoomTypeData = File.ReadAllText("../Context/DataSeeding/RoomType.json");
                var JsonRoomTypeData = JsonSerializer.Deserialize<List<RoomType>>(RoomTypeData);
                if (JsonRoomTypeData?.Count() > 0)
                {
                    foreach(var RoomTypeItem in JsonRoomTypeData)
                    {
                        hotelDbContext.roomType.Add(RoomTypeItem);
                    }
                    await hotelDbContext.SaveChangesAsync();
                }

                // Input Room Data
                var RoomData = File.ReadAllText("../Context/DataSeeding/Room.json");
                var JsonRoomData = JsonSerializer.Deserialize<List<Room>>(RoomData);
                if (JsonRoomData?.Count() > 0)
                {
                    foreach (var RoomItem in JsonRoomData)
                    {
                        hotelDbContext.room.Add(RoomItem);
                    }
                    await hotelDbContext.SaveChangesAsync();
                }

                // Input Season Data
                var SeasonData = File.ReadAllText("../Context/DataSeeding/Season.json");
                var JsonSeasonData = JsonSerializer.Deserialize<List<Season>>(SeasonData);
                if (JsonSeasonData?.Count() > 0)
                {
                    foreach (var SeasonItem in JsonSeasonData)
                    {
                        hotelDbContext.season.Add(SeasonItem);
                    }
                    await hotelDbContext.SaveChangesAsync();
                }

                // Input Room Rate Data
                var RoomRateData = File.ReadAllText("../Context/DataSeeding/RoomRate.json");
                var JsonRoomRateData = JsonSerializer.Deserialize<List<RoomRate>>(RoomRateData);
                if (JsonRoomRateData?.Count() > 0)
                {
                    foreach (var RoomRateItem in JsonRoomRateData)
                    {
                        hotelDbContext.roomRate.Add(RoomRateItem);
                    }
                    await hotelDbContext.SaveChangesAsync();
                }

                // Input Meal Plan
                var MealPlanData = File.ReadAllText("../Context/DataSeeding/MealPlan.json");
                var JsonMealPlanData = JsonSerializer.Deserialize<List<MealPlan>>(MealPlanData);
                if (JsonMealPlanData?.Count() > 0)
                {
                    foreach (var MealPlanItem in JsonMealPlanData)
                    {
                        hotelDbContext.mealPlan.Add(MealPlanItem);
                    }
                    await hotelDbContext.SaveChangesAsync();
                }

                // Input Meal Plan Rate
                var MealPlanRateData = File.ReadAllText("../Context/DataSeeding/MealPlanRate.json");
                var JsonMealPlanRateData = JsonSerializer.Deserialize<List<MealPlanRate>>(MealPlanRateData);
                if (JsonMealPlanRateData?.Count() > 0)
                {
                    foreach (var MealPlanRateItem in JsonMealPlanRateData)
                    {
                        hotelDbContext.mealPlanRate.Add(MealPlanRateItem);
                    }
                    await hotelDbContext.SaveChangesAsync();
                }
            }
        }
    }
}
