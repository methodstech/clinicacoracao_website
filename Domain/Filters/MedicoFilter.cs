using System;

namespace Domain.Filters
{
    public class MedicoFilter
    {
        public int? MedicoId { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }
        public DateTime? MedicoDtCadastro { get; set; }
    }
}
