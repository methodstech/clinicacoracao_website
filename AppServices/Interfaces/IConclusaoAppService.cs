using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IConclusaoAppService
    {
        ConclusaoDto Create(ConclusaoDto conclusao);
        IEnumerable<ConclusaoDto> List(ConclusaoFilterDto filter);
        ConclusaoDto GetById(int id);
        bool Update(ConclusaoDto conclusao);
        bool Delete(int id);
    }
}
