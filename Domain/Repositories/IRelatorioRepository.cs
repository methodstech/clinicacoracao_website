using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRelatorioRepository : IRepository<Entities.RelatorioHistoricoPaciente, Filters.RelatorioHistoricoPacienteFilter>
    {
        IEnumerable<RelatorioHistoricoPaciente> RelatorioHistoricoPaciente(Filters.RelatorioHistoricoPacienteFilter filter);
        RelatorioRitmoConclusao RelatorioRitmoConclusao(Filters.RelatorioRitmoConclusaoFilter filter);
        IEnumerable<RelatorioRitmoConclusaoDetalhes> RelatorioRitmoConclusaoDetalhes(Filters.RelatorioRitmoConclusaoFilter filter);
    }
}
