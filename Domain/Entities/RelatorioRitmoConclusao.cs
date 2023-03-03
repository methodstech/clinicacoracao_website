using System.Collections.Generic;

namespace Domain.Entities
{
    public class RelatorioRitmoConclusao
    {
        public int QuantidadeTotal { get; set; }
        public int QuantidadeFiltrada { get; set; }
        public IEnumerable<RelatorioRitmoConclusaoDetalhes> Laudos { get; set; }
    }
}
