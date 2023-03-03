using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IRitmoAppService
    {
        RitmoDto Create(RitmoDto ritmo);
        IEnumerable<RitmoDto> List(RitmoFilterDto ritmo);
        RitmoDto GetById(int id);
        bool Update(RitmoDto ritmo);
        bool Delete(int id);
    }
}
