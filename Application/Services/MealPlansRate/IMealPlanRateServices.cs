using Models.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MealPlansRate
{
    public interface IMealPlanRateServices
    {
        MealPlanRate GetMealPlanRateBySeasonAndMealPlan(int SeasonId, int MealPlanId);
    }
}
