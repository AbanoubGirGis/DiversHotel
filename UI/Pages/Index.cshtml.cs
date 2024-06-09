using Application.Contract;
using Application.DTO;
using Application.Services.Guests;
using Application.Services.MealPlansRate;
using Application.Services.MeanPlans;
using Application.Services.Reservations;
using Application.Services.RoomsRate;
using Application.Services.RoomTypes;
using Application.Services.Seasons;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Guests;
using Models.MealPlans;
using Models.Reservation;
using Models.Room;
using Models.Seasons;
using System.Collections.Generic;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGuestServices _IGuestServices;
        private readonly IRoomsTypesServices _IRoomsTypesServices;
        private readonly IMealPlanServices _IMealPlanServices;
        private readonly IReservationsServices _IReservationsServices;
        private readonly ISeasonServices _ISeasonServices;
        private readonly IRoomRateServices _IRoomRateServices;
        private readonly IMealPlanRateServices _IMealPlanRateServices;

        public IndexModel(IGuestServices iGuestServices,
            IRoomsTypesServices iRoomsTypesServices,
            IMealPlanServices iMealPlanServices,
            IReservationsServices iReservationsServices,
            ISeasonServices iSeasonServices,
            IRoomRateServices iroomRateServices,
            IMealPlanRateServices imealPlanRateServices)
        {
            _IGuestServices = iGuestServices;
            _IRoomsTypesServices = iRoomsTypesServices;
            _IMealPlanServices = iMealPlanServices;
            _IReservationsServices = iReservationsServices;
            _ISeasonServices = iSeasonServices;
            _IRoomRateServices = iroomRateServices;
            _IMealPlanRateServices = imealPlanRateServices;
        }

        public List<RoomType> RoomTypeList { get; set; } = new List<RoomType>();
        public List<MealPlan> MealPlanList { get; set; } = new List<MealPlan>();
        public double TotalPrice { get; set; } 
        [BindProperty]
        public GuestReservationDTO guestReservationDTO { get; set; } = new GuestReservationDTO();


        public void OnGet()
        {
            RoomTypeList = _IRoomsTypesServices.GetAllRoomsTypes();
            MealPlanList = _IMealPlanServices.GetAllMealPlans();
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                int NumberOfGuests = guestReservationDTO.NumberOfAdults + guestReservationDTO.NumberOfChildren;

                TotalPrice = ClaculateTotalPrice(guestReservationDTO.CheckIn, guestReservationDTO.CheckOut,
                                    NumberOfGuests, guestReservationDTO.RoomTypeId, guestReservationDTO.MealPlanId);

                var guest = new Guest
                {
                    Name = guestReservationDTO.GuestName,
                    Email = guestReservationDTO.GuestEmail,
                    Country = guestReservationDTO.GuestCountry
                };

                Guest guestCreated = _IGuestServices.CreateNewGuest(guest);

                var reservation = new Reservation
                {
                    GuestId = guestCreated.ID,
                    RoomTypeId = guestReservationDTO.RoomTypeId,
                    MealPlanId = guestReservationDTO.MealPlanId,
                    CheckIn = guestReservationDTO.CheckIn,
                    CheckOut = guestReservationDTO.CheckOut,
                    NumberOfAdults = guestReservationDTO.NumberOfAdults,
                    NumberOfChildren = guestReservationDTO.NumberOfChildren,
                    TotalPrice = ((decimal)TotalPrice)
                };

                _IReservationsServices.CreateNewReservation(reservation);

                TempData["InputData"] = TotalPrice.ToString();
                return RedirectToPage("Submitted");
            }

            RoomTypeList = _IRoomsTypesServices.GetAllRoomsTypes();
            MealPlanList = _IMealPlanServices.GetAllMealPlans();
            return Page();
        }

        public double ClaculateTotalPrice(DateTime CheckIn, DateTime CheckOut, int NumberOfGuests, int RoomTypeId, int MealPlanId)
        {
            Season SeasonPredict = _ISeasonServices.PredictSeason(CheckIn, CheckOut);

            RoomRate roomRate = _IRoomRateServices.GetRoomRateBySeasonAndRoomType(RoomTypeId, SeasonPredict.ID);

            MealPlanRate mealPlanRate = _IMealPlanRateServices.GetMealPlanRateBySeasonAndMealPlan(SeasonPredict.ID,MealPlanId);

            double NumberOfNights = _IReservationsServices.CalculateDaysByDates(CheckIn,CheckOut);

            double RoomRatePerNight = (double)roomRate.RatePerNight;

            double RoomRatePerAllNights = RoomRatePerNight * NumberOfNights;

            double MealPlanRatePerGuests = (double)mealPlanRate.RatePerPerson * NumberOfGuests;

            double TotalPrice = RoomRatePerAllNights + MealPlanRatePerGuests;

            return TotalPrice;

        }
    }
}
