using Models.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Guests
{
    public interface IGuestServices
    {
        public Guest CreateNewGuest(Guest guest);
    }
}
