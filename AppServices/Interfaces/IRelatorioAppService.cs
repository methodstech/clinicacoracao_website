using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IRelatorioAppService
    {
        IEnumerable<RelatorioHistoricoPacienteDto> RelatorioHistoricoPaciente(RelatorioHistoricoPacienteFilterDto filter);
        RelatorioRitmoConclusaoDto RelatorioRitmoConclusao(RelatorioRitmoConclusaoFilterDto filter);
    }
}
