using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Filters;
using DomainServices.Interfaces;
using AppServices.Extensions;
using Domain.Entities;
using Domain.Filters;
using System.Data;

namespace AppServices.Service
{
    internal class LaudoAppService : Interfaces.ILaudoAppService
    {
        private readonly ILaudoDomainService _service;

        public LaudoAppService(ILaudoDomainService service)
        {
            _service = service;
        }

        public LaudoDto Create(LaudoDto laudo)
        {
            var result = _service.Create(laudo.MapTo<Laudo>());
            return result.MapTo<LaudoDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public LaudoDto GetById(int id)
        {
            return _service.GetById(id).MapTo<LaudoDto>();
        }

        public IEnumerable<LaudoDto> List(LaudoFilterDto filter)
        {
            return _service.List(filter.MapTo<LaudoFilter>()).Enumerable<LaudoDto>();
        }

        public DataTable ListDataTable(LaudoFilterDto filter)
        {
            return _service.ListDataTable(filter.MapTo<LaudoFilter>());
        }

        public bool Update(LaudoDto laudo)
        {
            return _service.Update(laudo.MapTo<Laudo>());
        }
    }
}
