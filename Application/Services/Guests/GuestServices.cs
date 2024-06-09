using Application.Contract;
using Models.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Guests
{
    public class GuestServices : ValidationsGuests, IGuestServices
    {
        private readonly IRepository<Guest> _IRepository;

        public GuestServices(IRepository<Guest> _iRepository)
        {
            _IRepository = _iRepository;
        }
        public Guest CreateNewGuest(Guest guest)
        {
            if (IsValidNameAndCountry(guest.Name) &&
                IsValidNameAndCountry(guest.Country) &&
                IsValidemail(guest.Email))
            {
                return _IRepository.CreateEntity(guest);
            }
            else
            {
                return null;
            }
        }
    }
}
