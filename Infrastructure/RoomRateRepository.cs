using Application.Contract;
using Context;
using Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RoomRateRepository : Repository<RoomRate> , IRepositoryRoomRate
    {
        HotelDbContext hotelDbContext;
        public RoomRateRepository(HotelDbContext _hotelDbContext) : base(_hotelDbContext)
        {
            hotelDbContext = _hotelDbContext ?? throw new ArgumentNullException(nameof(_hotelDbContext));
        }

        public RoomRate GetRoomRateBySeasonIdAndRoomTypeId(int RoomTypeId , int SeasonId)
        {
            var RoomRateSelected = hotelDbContext.roomRate.FirstOrDefault(s => s.RoomTypeId == RoomTypeId &&
                                                                                s.SeasonId == SeasonId);
            return RoomRateSelected;
        }
    }
}
