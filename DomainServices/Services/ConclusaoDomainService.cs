using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace DomainServices.Services
{
    internal class ConclusaoDomainService : Interfaces.IConclusaoDomainService
    {
        private readonly IConclusaoRepository _repository;

        public ConclusaoDomainService(IConclusaoRepository repository)
        {
            _repository = repository;
        }

        public Conclusao Create(Conclusao conclusao)
        {
            return _repository.Create(conclusao);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Conclusao GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Conclusao> List(ConclusaoFilter filter)
        {
            return _repository.List(filter);
        }

        public bool Update(Conclusao conclusao)
        {
            return _repository.Update(conclusao);
        }
    }
}
