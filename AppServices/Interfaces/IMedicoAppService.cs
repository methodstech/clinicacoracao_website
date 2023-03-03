using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IMedicoAppService
    {
        MedicoDto Create(MedicoDto medico);
        IEnumerable<MedicoDto> List(MedicoFilterDto filter);
        MedicoDto GetById(int id);
        bool Update(MedicoDto medico);
        bool Delete(int id);
    }
}
