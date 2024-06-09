using Models.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IRepositoryMealPlanRate : IRepository<MealPlanRate>
    {
        MealPlanRate GetMealPlanRateBySeasonIdAndMealPlanId(int SeasonId, int MealPlanId);
    }
}
