using System;

namespace AppServices.Filters
{
    public class RitmoFilterDto
    {
        public int? RitmoId { get; set; }
        public int? RitmoCodigo { get; set; }
        public string RitmoDescricao { get; set; }
        public DateTime? DtCadastro { get; set; }
    }
}
