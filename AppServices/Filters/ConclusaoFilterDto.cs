using System;

namespace AppServices.Filters
{
    public class ConclusaoFilterDto
    {
        public int? ConclusaoId { get; set; }
        public string ConclusaoCodigo { get; set; }
        public string ConclusaoDescricao { get; set; }
        public DateTime? ConclusaoDtCadastro { get; set; }
        public int? LaudoId { get; set; }
    }
}
