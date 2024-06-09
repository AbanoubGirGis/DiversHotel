using Application.Contract;
using Context;
using Models.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SeasonRepository : Repository<Season> , IRepositorySeason
    {
        HotelDbContext hotelDbContext;
        public SeasonRepository(HotelDbContext _hotelDbContext) : base(_hotelDbContext)
        {
            hotelDbContext = _hotelDbContext ?? throw new ArgumentNullException(nameof(_hotelDbContext));
        }

        public Season PredictSeasonByDates(DateTime CheckInDate , DateTime CheckOutDate)
        {
            var SeasonPredict = hotelDbContext.season.FirstOrDefault(s => CheckInDate >= s.StartDate && CheckOutDate <= s.EndDate);
            return SeasonPredict;
        }
    }
}
