using Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Reservations
{
    public interface IReservationsServices
    {
        public Reservation CreateNewReservation(Reservation reservation);

        public double CalculateDaysByDates(DateTime CheckInDate, DateTime checkOutDate);
    }
}
