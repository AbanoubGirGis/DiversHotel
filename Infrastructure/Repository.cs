using Application.Contract;
using Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HotelDbContext hotelDbContext;
        private readonly DbSet<T> DbSetEntity;

        public Repository(HotelDbContext _hotelDbContext)
        {
            hotelDbContext = _hotelDbContext;
            DbSetEntity = _hotelDbContext.Set<T>();
        }

        public List<T> GetAllEntities() 
        {
            return DbSetEntity.ToList();
        }

        public T CreateEntity(T entity)
        {
            DbSetEntity.Add(entity);
            SaveEntity();
            return entity;
        }

        public int SaveEntity()
        {
            return hotelDbContext.SaveChanges();
        }
    }
}
