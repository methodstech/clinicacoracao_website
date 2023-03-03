using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Filters;
using DomainServices.Interfaces;
using Domain.Entities;
using AppServices.Extensions;
using Domain.Filters;

namespace AppServices.Service
{
    internal class ConclusaoAppService : Interfaces.IConclusaoAppService
    {
        private readonly IConclusaoDomainService _service;

        public ConclusaoAppService(IConclusaoDomainService service)
        {
            _service = service;
        }

        public ConclusaoDto Create(ConclusaoDto conclusao)
        {
            var result = _service.Create(conclusao.MapTo<Conclusao>());
            return result.MapTo<ConclusaoDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public ConclusaoDto GetById(int id)
        {
            return _service.GetById(id).MapTo<ConclusaoDto>();
        }

        public IEnumerable<ConclusaoDto> List(ConclusaoFilterDto filter)
        {
            return _service.List(filter.MapTo<ConclusaoFilter>()).Enumerable<ConclusaoDto>();
        }

        public bool Update(ConclusaoDto conclusao)
        {
            return _service.Update(conclusao.MapTo<Conclusao>());
        }
    }
}
