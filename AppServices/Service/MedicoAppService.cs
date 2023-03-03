using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using DomainServices.Interfaces;
using AppServices.Extensions;
using AppServices.Dtos;
using AppServices.Filters;

namespace AppServices.Service
{
    internal class MedicoAppService : Interfaces.IMedicoAppService
    {
        private readonly IMedicoDomainService _service;

        public MedicoAppService(IMedicoDomainService service)
        {
            _service = service;
        }

        public MedicoDto Create(MedicoDto medico)
        {
            var result = _service.Create(medico.MapTo<Medico>());
            return result.MapTo<MedicoDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public MedicoDto GetById(int id)
        {
            return _service.GetById(id).MapTo<MedicoDto>();
        }

        public IEnumerable<MedicoDto> List(MedicoFilterDto filter)
        {
            return _service.List(filter.MapTo<MedicoFilter>()).Enumerable<MedicoDto>();
        }

        public bool Update(MedicoDto medico)
        {
            return _service.Update(medico.MapTo<Medico>());
        }
    }
}
