using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace DomainServices.Services
{
    internal class ConvenioDomainService : Interfaces.IConvenioDomainService
    {
        private readonly IConvenioRepository _repository;

        public ConvenioDomainService(IConvenioRepository repository)
        {
            _repository = repository;
        }

        public Convenio Create(Convenio convenio)
        {
            return _repository.Create(convenio);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Convenio GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Convenio> List(ConvenioFilter filter)
        {
            return _repository.List(filter);
        }

        public bool Update(Convenio convenio)
        {
            return _repository.Update(convenio);
        }
    }
}

