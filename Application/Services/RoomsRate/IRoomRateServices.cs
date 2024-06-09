using Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.RoomsRate
{
    public interface IRoomRateServices
    {
        RoomRate GetRoomRateBySeasonAndRoomType(int RoomTypeId, int SeasonId);
    }
}
