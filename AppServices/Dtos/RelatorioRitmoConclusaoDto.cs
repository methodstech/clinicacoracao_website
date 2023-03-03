using System.Collections.Generic;

namespace AppServices.Dtos
{
    public class RelatorioRitmoConclusaoDto
    {
        public int QuantidadeTotal { get; set; }
        public int QuantidadeFiltrada { get; set; }
        public IEnumerable<RelatorioRitmoConclusaoDetalhesDto> Laudos { get; set; }
    }
}
