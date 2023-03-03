using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Filters;
using DomainServices.Interfaces;
using Domain.Entities;
using AppServices.Extensions;
using Domain.Filters;

namespace AppServices.Service
{
    internal class ConvenioAppService : Interfaces.IConvenioAppService
    {
        private readonly IConvenioDomainService _service;

        public ConvenioAppService(IConvenioDomainService service)
        {
            _service = service;
        }

        public ConvenioDto Create(ConvenioDto convenio)
        {
            var result = _service.Create(convenio.MapTo<Convenio>());
            return result.MapTo<ConvenioDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public ConvenioDto GetById(int id)
        {
            return _service.GetById(id).MapTo<ConvenioDto>();
        }

        public IEnumerable<ConvenioDto> List(ConvenioFilterDto filter)
        {
            return _service.List(filter.MapTo<ConvenioFilter>()).Enumerable<ConvenioDto>();
        }

        public bool Update(ConvenioDto convenio)
        {
            return _service.Update(convenio.MapTo<Convenio>());
        }
    }
}
