using Application.Contract;
using Models.Guests;
using Models.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Seasons
{
    public class SeasonServices : ISeasonServices
    {
        private readonly IRepositorySeason _IRepository;

        public SeasonServices(IRepositorySeason _iRepository)
        {
            _IRepository = _iRepository;
        }

        public Season PredictSeason(DateTime CheckIn, DateTime CheckOut)
        {
            Season season = _IRepository.PredictSeasonByDates(CheckIn, CheckOut);

            if(season == null)
            {
                return null;
            }

            return season;
        }
    }
}
