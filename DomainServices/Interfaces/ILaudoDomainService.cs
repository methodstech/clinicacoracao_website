using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;
using System.Data;

namespace DomainServices.Interfaces
{
    public interface ILaudoDomainService
    {
        Laudo Create(Laudo laudo);
        IEnumerable<Laudo> List(LaudoFilter filter);
        Laudo GetById(int id);
        bool Update(Laudo laudo);
        bool Delete(int id);
        DataTable ListDataTable(LaudoFilter filter);
    }
}
