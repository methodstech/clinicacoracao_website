using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Filters;
using DomainServices.Interfaces;
using Domain.Entities;
using AppServices.Extensions;
using Domain.Filters;

namespace AppServices.Service
{
    internal class UsuarioAppService : Interfaces.IUsuarioAppService
    {
        private readonly IUsuarioDomainService _service;

        public UsuarioAppService(IUsuarioDomainService service)
        {
            _service = service;
        }

        public UsuarioDto Create(UsuarioDto usuario)
        {
            var result = _service.Create(usuario.MapTo<Usuario>());
            return result.MapTo<UsuarioDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public UsuarioDto GetById(int id)
        {
            return _service.GetById(id).MapTo<UsuarioDto>();
        }

        public IEnumerable<UsuarioDto> List(UsuarioFilterDto filter)
        {
            return _service.List(filter.MapTo<UsuarioFilter>()).Enumerable<UsuarioDto>();
        }

        public bool Update(UsuarioDto usuario)
        {
            return _service.Update(usuario.MapTo<Usuario>());
        }
    }
}
