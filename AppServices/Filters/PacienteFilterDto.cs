using System;

namespace AppServices.Filters
{
    public class PacienteFilterDto
    {
        public int? PacienteId { get; set; }
        public string PacienteNome { get; set; }
        public DateTime? PacienteDataNascimento { get; set; }
        public DateTime? PacienteDtCadastro { get; set; }
    }
}
