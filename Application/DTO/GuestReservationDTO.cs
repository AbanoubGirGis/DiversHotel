using Application.DTO.ValidationsDTO;
using Models.Guests;
using Models.MealPlans;
using Models.Room;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class GuestReservationDTO
    {
        [Required(ErrorMessage = "Name is Requird")]
        [MinLength(3, ErrorMessage = "Name should be greater than 3")]
        [MaxLength(40, ErrorMessage = "Name should be less than 40")]
        public string GuestName { get; set; }

        [Required]
        [EmailCustomValidation]
        public string GuestEmail { get; set; }

        [Required(ErrorMessage = "Country is Requird")]
        [MinLength(3, ErrorMessage = "Country should be greater than 3")]
        [MaxLength(40, ErrorMessage = "Country should be less than 40")]
        public string GuestCountry { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        [Required]
        public int MealPlanId { get; set; }

        [Required]
        [CheckInCustomValidation]
        public DateTime CheckIn { get; set; }

        [Required]
        [CheckOutCustomValidation]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Input at least One Adult")]
        [Range(1, 2, ErrorMessage = "Number of Adults at least one Adult and Max 2 Adults")]
        public int NumberOfAdults { get; set; }

        [Range(0, 2, ErrorMessage = "Max Number of Children is 2")]
        public int NumberOfChildren { get; set; }
    }
}
