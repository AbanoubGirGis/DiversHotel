using Models.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MeanPlans
{
    public interface IMealPlanServices
    {
        public List<MealPlan> GetAllMealPlans();
    }
}
