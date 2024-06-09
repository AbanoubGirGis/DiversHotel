using Models.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IRepository<T>
    {
        T CreateEntity(T entity);

        List<T> GetAllEntities();

        int SaveEntity();
    }
}
