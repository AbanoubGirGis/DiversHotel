using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services.Guests
{
    public class ValidationsGuests
    {
        protected bool IsValidNameAndCountry(string NameOrCountry)
        {
            if (NameOrCountry.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsValidemail(string Email)
        {
            string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(Email, EmailPattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
