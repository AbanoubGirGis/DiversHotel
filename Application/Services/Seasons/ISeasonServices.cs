using Models.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Seasons
{
    public interface ISeasonServices
    {
        public Season PredictSeason(DateTime CheckIn , DateTime CheckOut );
    }
}
