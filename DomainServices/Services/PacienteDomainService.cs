using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace DomainServices.Services
{
    internal class PacienteDomainService : Interfaces.IPacienteDomainService
    {
        private readonly IPacienteRepository _repository;

        public PacienteDomainService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public Paciente Create(Paciente paciente)
        {
            return _repository.Create(paciente);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Paciente GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Paciente> List(PacienteFilter filter)
        {
            return _repository.List(filter);
        }

        public bool Update(Paciente paciente)
        {
            return _repository.Update(paciente);
        }
    }
}
