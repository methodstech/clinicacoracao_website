using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<T, TFiltro> : IRepository
    {
        T Create(T obj);
        IEnumerable<T> List(TFiltro filter);
        T GetById(int id);
        bool Update(T obj);
        bool Delete(int id);
    }
}
