using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ValidationsDTO
{
    public class CheckInCustomValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _GuestReservationDTO = (GuestReservationDTO)validationContext.ObjectInstance;

            var CheckInValue = (DateTime)_GuestReservationDTO.CheckIn;
            var CurrentDateValue = DateTime.Now;

            if (CurrentDateValue > CheckInValue)
            {
                return new ValidationResult("Invalid Check In Date");
            }

            return ValidationResult.Success;
        }
    }
}
