using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioDto Create(UsuarioDto usuario);
        IEnumerable<UsuarioDto> List(UsuarioFilterDto filter);
        UsuarioDto GetById(int id);
        bool Update(UsuarioDto usuario);
        bool Delete(int id);
    }
}
