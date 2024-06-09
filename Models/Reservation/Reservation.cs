using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Guests;
using Models.MealPlans;
using Models.Room;

namespace Models.Reservation
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Guest")]
        public int GuestId { get; set; }

        public Guest guest { get; set; }

        [Required]
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        public RoomType roomType { get; set; }

        [Required]
        [ForeignKey("MealPlan")]
        public int MealPlanId { get; set; }

        public MealPlan mealPlan { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public int NumberOfAdults { get; set; }

        public int NumberOfChildren { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
