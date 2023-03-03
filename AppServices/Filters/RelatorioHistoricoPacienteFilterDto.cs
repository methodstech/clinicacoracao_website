using System;

namespace AppServices.Filters
{
    public class RelatorioHistoricoPacienteFilterDto
    {
        public int? LaudoId { get; set; }
        public int? PacienteId { get; set; }
        public string Paciente { get; set; }
        public string Convenio { get; set; }
        public string Laudador { get; set; }
        public string Solicitante { get; set; }
        public DateTime? DtCadastro { get; set; }
    }
}
