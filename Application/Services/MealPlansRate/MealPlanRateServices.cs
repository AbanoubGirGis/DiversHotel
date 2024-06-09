using Application.Contract;
using Models.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MealPlansRate
{
    public class MealPlanRateServices : IMealPlanRateServices
    {
        private readonly IRepositoryMealPlanRate _IRepository;

        public MealPlanRateServices(IRepositoryMealPlanRate _iRepository)
        {
            _IRepository = _iRepository;
        }

        public MealPlanRate GetMealPlanRateBySeasonAndMealPlan(int SeasonId, int MealPlanId)
        {
            MealPlanRate MealPlanRateSelected = _IRepository.GetMealPlanRateBySeasonIdAndMealPlanId(SeasonId, MealPlanId);

            if(MealPlanRateSelected == null)
            {
                return null;
            }

            return MealPlanRateSelected;
        }
    }
}
