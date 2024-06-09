using Application.Contract;
using Context;
using Models.MealPlans;
using Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MealPlanRateRepository : Repository<MealPlanRate> , IRepositoryMealPlanRate
    {
        HotelDbContext hotelDbContext;
        public MealPlanRateRepository(HotelDbContext _hotelDbContext) : base(_hotelDbContext)
        {
            hotelDbContext = _hotelDbContext ?? throw new ArgumentNullException(nameof(_hotelDbContext));
        }

        public MealPlanRate GetMealPlanRateBySeasonIdAndMealPlanId(int SeasonId , int MealPlanId)
        {
            var MealPlanRateSelected = hotelDbContext.mealPlanRate.FirstOrDefault(m => m.MealPlanId == MealPlanId &&
                                                                                  m.SeasonId == SeasonId);
            return MealPlanRateSelected;
        }
    }
}

