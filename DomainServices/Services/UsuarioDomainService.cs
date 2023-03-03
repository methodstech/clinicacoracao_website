using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace DomainServices.Services
{
    internal class UsuarioDomainService : Interfaces.IUsuarioDomainService
    {
        private readonly IUsuarioRepository repository;

        public UsuarioDomainService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public Usuario Create(Usuario usuario)
        {
            return repository.Create(usuario);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public Usuario GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Usuario> List(UsuarioFilter filter)
        {
            return repository.List(filter);
        }

        public bool Update(Usuario usuario)
        {
            return repository.Update(usuario);
        }
    }
}
