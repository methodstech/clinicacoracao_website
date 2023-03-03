using System;

namespace AppServices.Filters
{
    public class RelatorioRitmoConclusaoFilterDto
    {
        public int RitmoId { get; set; }
        public int ConclusaoId { get; set; }
        public DateTime? DtInicial { get; set; }
        public DateTime? DtFinal { get; set; }
    }
}
