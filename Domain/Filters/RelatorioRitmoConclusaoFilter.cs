using System;

namespace Domain.Filters
{
    public class RelatorioRitmoConclusaoFilter
    {
        public int RitmoId { get; set; }
        public int ConclusaoId { get; set; }
        public DateTime? DtInicial { get; set; }
        public DateTime? DtFinal { get; set; }
    }
}
