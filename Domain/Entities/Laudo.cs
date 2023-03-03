using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Laudo
    {
        /*Properties comuns*/
        public int LaudoId { get; set; }
        public string LaudoComplemento { get; set; }
        public DateTime LaudoDtCadastro { get; set; }
        public DateTime LaudoDtRealizacao { get; set; }

        /*Properties utilizadas para insert e update*/
        public int LaudoPacienteId { get; set; }
        public int LaudoConvenioId { get; set; }
        public int LaudoMedicoLaudadorId { get; set; }
        public int LaudoMedicoSolicitanteId { get; set; }
        public int LaudoRitmoId { get; set; }
        public string LaudoConclusoesId { get; set; } /* string contendo id's separados por '-' */

        /*Properties utilizadas nas buscas, para exibir em tela*/
        public Paciente LaudoPaciente { get; set; }
        public Convenio LaudoConvenio { get; set; }
        public Medico LaudoMedicoLaudador { get; set; }
        public Medico LaudoMedicoSolicitante { get; set; }
        public Ritmo LaudoRitmo { get; set; }
        public IEnumerable<Conclusao> LaudoConclusoes { get; set; }
    }
}
