using System;

namespace AppServices.Filters
{
    public class LaudoFilterDto
    {
        public int? LaudoId { get; set; }
        public string LaudoComplemento { get; set; }
        public DateTime? LaudoDtCadastro { get; set; }
        public DateTime? LaudoDtInicial { get; set; }
        public DateTime? LaudoDtFinal { get; set; }
        public int? LaudoPacienteId { get; set; }
        public int? LaudoConvenioId { get; set; }
        public int? LaudoMedicoLaudadorId { get; set; }
        public int? LaudoMedicoSolicitanteId { get; set; }
        public int? LaudoRitmoId { get; set; }
        public DateTime? LaudoDtRealizacao { get; set; }
    }
}
