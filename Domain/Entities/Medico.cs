using System;

namespace Domain.Entities
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }
        public DateTime MedicoDtCadastro { get; set; }
    }
}
