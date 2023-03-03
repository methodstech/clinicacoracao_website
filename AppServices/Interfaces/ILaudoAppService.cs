using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;
using System.Data;

namespace AppServices.Interfaces
{
    public interface ILaudoAppService
    {
        LaudoDto Create(LaudoDto laudo);
        IEnumerable<LaudoDto> List(LaudoFilterDto filter);
        LaudoDto GetById(int id);
        bool Update(LaudoDto laudo);
        bool Delete(int id);
        DataTable ListDataTable(LaudoFilterDto filter);
    }
}
