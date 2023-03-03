using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace DomainServices.Services
{
    internal class RitmoDomainService : Interfaces.IRitmoDomainService
    {
        private readonly IRitmoRepository _repository;

        public RitmoDomainService(IRitmoRepository repository)
        {
            _repository = repository;
        }

        public Ritmo Create(Ritmo ritmo)
        {
            return _repository.Create(ritmo);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Ritmo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Ritmo> List(RitmoFilter filter)
        {
            return _repository.List(filter);
        }

        public bool Update(Ritmo ritmo)
        {
            return _repository.Update(ritmo);
        }
    }
}
