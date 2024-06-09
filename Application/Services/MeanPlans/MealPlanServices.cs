using Application.Contract;
using Models.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MeanPlans
{
    public class MealPlanServices : IMealPlanServices
    {
        private readonly IRepository<MealPlan> _IRepository;

        public MealPlanServices(IRepository<MealPlan> _iRepository) 
        {
            _IRepository = _iRepository; 
        }

        public List<MealPlan> GetAllMealPlans()
        {
            return _IRepository.GetAllEntities();
        }
    }
}
