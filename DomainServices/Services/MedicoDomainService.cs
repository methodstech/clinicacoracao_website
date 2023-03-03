using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace DomainServices.Services
{
    internal class MedicoDomainService : Interfaces.IMedicoDomainService
    {
        private readonly IMedicoRepository _repository;

        public MedicoDomainService(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public Medico Create(Medico medico)
        {
            return _repository.Create(medico);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Medico GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Medico> List(MedicoFilter filter)
        {
            return _repository.List(filter);
        }

        public bool Update(Medico ritmo)
        {
            return _repository.Update(ritmo);
        }
    }
}
