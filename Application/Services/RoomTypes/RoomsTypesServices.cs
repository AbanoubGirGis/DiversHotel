using Application.Contract;
using Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.RoomTypes
{
    public class RoomsTypesServices : IRoomsTypesServices
    {
        private readonly IRepository<RoomType> _IRepository;

        public RoomsTypesServices(IRepository<RoomType> _iRepository) 
        {
            _IRepository = _iRepository;
        }

        public List<RoomType> GetAllRoomsTypes()
        {
            return _IRepository.GetAllEntities();
        }
    }
}
