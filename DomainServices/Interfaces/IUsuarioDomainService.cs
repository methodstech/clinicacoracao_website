using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IUsuarioDomainService
    {
        Usuario Create(Usuario usuario);
        IEnumerable<Usuario> List(UsuarioFilter filter);
        Usuario GetById(int id);
        bool Update(Usuario usuario);
        bool Delete(int id);
    }
}
