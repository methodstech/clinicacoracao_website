using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace DomainServices.Services
{
    internal class RelatorioDomainService : Interfaces.IRelatorioDomainService
    {
        private readonly IRelatorioRepository _repository;

        public RelatorioDomainService(IRelatorioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RelatorioHistoricoPaciente> RelatorioHistoricoPaciente(RelatorioHistoricoPacienteFilter filter)
        {
            return _repository.RelatorioHistoricoPaciente(filter);
        }

        public RelatorioRitmoConclusao RelatorioRitmoConclusao(RelatorioRitmoConclusaoFilter filter)
        {
            var relatorio = _repository.RelatorioRitmoConclusao(filter);
            if (relatorio != null)
            {
                relatorio.Laudos = _repository.RelatorioRitmoConclusaoDetalhes(filter);
            }
            return relatorio;
        }
    }
}
