using System.Collections.Generic;
using AppServices.Dtos;
using DomainServices.Interfaces;
using Domain.Filters;
using AppServices.Extensions;
using AppServices.Filters;

namespace AppServices.Service
{
    internal class RelatorioAppService : Interfaces.IRelatorioAppService
    {
        private readonly IRelatorioDomainService _service;

        public RelatorioAppService(IRelatorioDomainService service)
        {
            _service = service;
        }

        public IEnumerable<RelatorioHistoricoPacienteDto> RelatorioHistoricoPaciente(RelatorioHistoricoPacienteFilterDto filter)
        {
            return _service.RelatorioHistoricoPaciente(filter.MapTo<RelatorioHistoricoPacienteFilter>()).Enumerable<RelatorioHistoricoPacienteDto>();
        }

        public RelatorioRitmoConclusaoDto RelatorioRitmoConclusao(RelatorioRitmoConclusaoFilterDto filter)
        {
            return _service.RelatorioRitmoConclusao(filter.MapTo<RelatorioRitmoConclusaoFilter>()).MapTo<RelatorioRitmoConclusaoDto>();
        }
    }
}
