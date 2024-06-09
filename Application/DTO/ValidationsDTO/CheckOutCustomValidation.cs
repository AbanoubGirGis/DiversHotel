using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.DTO.ValidationsDTO
{
    public class CheckOutCustomValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _GuestReservationDTO = (GuestReservationDTO)validationContext.ObjectInstance;

            var checkInValue = (DateTime)_GuestReservationDTO.CheckIn;
            var checkOutValue = (DateTime)_GuestReservationDTO.CheckOut;

            if (checkInValue >= checkOutValue)
            {
                return new ValidationResult("Check Out date must be greater than check In date");
            }

            return ValidationResult.Success;
        }
    }
}
