using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Filters;
using DomainServices.Interfaces;
using Domain.Entities;
using AppServices.Extensions;
using Domain.Filters;

namespace AppServices.Service
{
    internal class RitmoAppService : Interfaces.IRitmoAppService
    {
        private readonly IRitmoDomainService _service;

        public RitmoAppService(IRitmoDomainService service)
        {
            _service = service;
        }

        public RitmoDto Create(RitmoDto ritmo)
        {
            var result = _service.Create(ritmo.MapTo<Ritmo>());
            return result.MapTo<RitmoDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public RitmoDto GetById(int id)
        {
            return _service.GetById(id).MapTo<RitmoDto>();
        }

        public IEnumerable<RitmoDto> List(RitmoFilterDto filter)
        {
            return _service.List(filter.MapTo<RitmoFilter>()).Enumerable<RitmoDto>();
        }

        public bool Update(RitmoDto ritmo)
        {
            return _service.Update(ritmo.MapTo<Ritmo>());
        }
    }
}
