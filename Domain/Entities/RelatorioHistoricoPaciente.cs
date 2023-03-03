using System;

namespace Domain.Entities
{
    public class RelatorioHistoricoPaciente
    {
        public int LaudoId { get; set; }
        public string Paciente { get; set; }
        public string Convenio { get; set; }
        public string Laudador { get; set; }
        public string Solicitante { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
