using Models.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IRepositorySeason : IRepository<Season>
    {
        Season PredictSeasonByDates(DateTime CheckInDate, DateTime CheckOutDate);
    }
}
