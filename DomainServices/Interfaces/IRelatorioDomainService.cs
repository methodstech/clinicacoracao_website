using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IRelatorioDomainService
    {
        IEnumerable<RelatorioHistoricoPaciente> RelatorioHistoricoPaciente(RelatorioHistoricoPacienteFilter filter);
        RelatorioRitmoConclusao RelatorioRitmoConclusao(RelatorioRitmoConclusaoFilter filter);
    }
}
