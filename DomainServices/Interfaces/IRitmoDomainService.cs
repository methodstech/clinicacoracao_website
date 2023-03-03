using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IRitmoDomainService
    {
        Ritmo Create(Ritmo ritmo);
        IEnumerable<Ritmo> List(RitmoFilter filter);
        Ritmo GetById(int id);
        bool Update(Ritmo ritmo);
        bool Delete(int id);
    }
}
