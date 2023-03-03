using System;

namespace AppServices.Filters
{
    public class ConvenioFilterDto
    {
        public int? ConvenioId { get; set; }
        public string ConvenioNome { get; set; }
        public DateTime? ConvenioDtCadastro { get; set; }
    }
}
