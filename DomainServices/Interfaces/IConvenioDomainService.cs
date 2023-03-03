using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IConvenioDomainService
    {
        Convenio Create(Convenio convenio);
        IEnumerable<Convenio> List(ConvenioFilter filter);
        Convenio GetById(int id);
        bool Update(Convenio convenio);
        bool Delete(int id);
    }
}
