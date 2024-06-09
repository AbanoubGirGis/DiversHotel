using Models.Reservation;
using Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.RoomTypes
{
    public interface IRoomsTypesServices
    {
        public List<RoomType> GetAllRoomsTypes();
    }
}
