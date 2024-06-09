using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.DTO.ValidationsDTO
{
    public class EmailCustomValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _GuestReservationDTO = (GuestReservationDTO)validationContext.ObjectInstance;
            string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(_GuestReservationDTO.GuestEmail, EmailPattern))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid Email");
            }
        }
    }
}