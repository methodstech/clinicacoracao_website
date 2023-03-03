using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IConvenioAppService
    {
        ConvenioDto Create(ConvenioDto convenio);
        IEnumerable<ConvenioDto> List(ConvenioFilterDto filter);
        ConvenioDto GetById(int id);
        bool Update(ConvenioDto convenio);
        bool Delete(int id);
    }
}
