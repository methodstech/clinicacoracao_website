using System;

namespace Domain.Filters
{
    public class PacienteFilter
    {
        public int? PacienteId { get; set; }
        public string PacienteNome { get; set; }
        public DateTime? PacienteDataNascimento { get; set; }
        public DateTime? PacienteDtCadastro { get; set; }
    }
}
