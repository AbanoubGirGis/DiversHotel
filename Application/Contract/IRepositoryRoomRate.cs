using Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IRepositoryRoomRate : IRepository<RoomRate>
    {
        RoomRate GetRoomRateBySeasonIdAndRoomTypeId(int RoomTypeId, int SeasonId);
    }
}
