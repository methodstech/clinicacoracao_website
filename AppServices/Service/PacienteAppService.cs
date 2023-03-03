using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Filters;
using DomainServices.Interfaces;
using Domain.Entities;
using AppServices.Extensions;
using Domain.Filters;

namespace AppServices.Service
{
    internal class PacienteAppService : Interfaces.IPacienteAppService
    {
        private readonly IPacienteDomainService _service;

        public PacienteAppService(IPacienteDomainService service)
        {
            _service = service;
        }

        public PacienteDto Create(PacienteDto paciente)
        {
            var result = _service.Create(paciente.MapTo<Paciente>());
            return result.MapTo<PacienteDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public PacienteDto GetById(int id)
        {
            return _service.GetById(id).MapTo<PacienteDto>();
        }

        public IEnumerable<PacienteDto> List(PacienteFilterDto filter)
        {
            return _service.List(filter.MapTo<PacienteFilter>()).Enumerable<PacienteDto>();
        }

        public bool Update(PacienteDto paciente)
        {
            return _service.Update(paciente.MapTo<Paciente>());
        }
    }
}
