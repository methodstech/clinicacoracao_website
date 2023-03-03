using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IConclusaoDomainService
    {
        Conclusao Create(Conclusao conclusao);
        IEnumerable<Conclusao> List(ConclusaoFilter filter);
        Conclusao GetById(int id);
        bool Update(Conclusao conclusao);
        bool Delete(int id);
    }
}
