using System;

namespace AppServices.Filters
{
    public class MedicoFilterDto
    {
        public int? MedicoId { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }
        public DateTime? MedicoDtCadastro { get; set; }
    }
}
