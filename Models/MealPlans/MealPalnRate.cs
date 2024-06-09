using Models.Seasons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MealPlans
{
    public class MealPlanRate
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("MealPlan")]
        public int MealPlanId { get; set; }

        public MealPlan mealPlan { get; set; }

        [Required]
        [ForeignKey("Season")]
        public int SeasonId { get; set; }

        public Season season { get; set; }

        [Required]
        public decimal RatePerPerson { get; set; }
    }
}
