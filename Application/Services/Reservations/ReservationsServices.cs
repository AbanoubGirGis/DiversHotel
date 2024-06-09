using Application.Contract;
using Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Reservations
{
    public class ReservationsServices : IReservationsServices
    {
        private readonly IRepository<Reservation> _IRepository;

        public ReservationsServices(IRepository<Reservation> _iRepository)
        {
            _IRepository = _iRepository;
        }

        public Reservation CreateNewReservation(Reservation reservation)
        {
            return _IRepository.CreateEntity(reservation);
        }

        public double CalculateDaysByDates(DateTime CheckInDate, DateTime checkOutDate)
        {
            double NumberOfDays = (checkOutDate - CheckInDate).TotalDays;
            return NumberOfDays;
        }
    }
}
