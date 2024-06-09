using Application.Contract;
using Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.RoomsRate
{
    public class RoomRateServices : IRoomRateServices
    {
        private readonly IRepositoryRoomRate _IRepository;

        public RoomRateServices(IRepositoryRoomRate _iRepository)
        {
            _IRepository = _iRepository;
        }

        public RoomRate GetRoomRateBySeasonAndRoomType(int RoomTypeId, int SeasonId)
        {
            RoomRate RoomRateSelected = _IRepository.GetRoomRateBySeasonIdAndRoomTypeId(RoomTypeId, SeasonId);

            if (RoomRateSelected == null)
            {
                return null;
            }
            return RoomRateSelected;
        }
    }
}
