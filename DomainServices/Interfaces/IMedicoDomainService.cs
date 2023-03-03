using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IMedicoDomainService
    {
        Medico Create(Medico medico);
        IEnumerable<Medico> List(MedicoFilter filter);
        Medico GetById(int id);
        bool Update(Medico medico);
        bool Delete(int id);
    }
}
