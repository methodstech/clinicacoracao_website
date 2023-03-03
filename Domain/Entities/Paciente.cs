using System;

namespace Domain.Entities
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string PacienteNome { get; set; }
        public DateTime PacienteDataNascimento { get; set; }
        public DateTime PacienteDtCadastro { get; set; }
    }
}
