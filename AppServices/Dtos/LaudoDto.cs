using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AppServices.Dtos
{
    public class LaudoDto
    {
        /*Properties comuns*/
        public int LaudoId { get; set; }
        public string LaudoComplemento { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime LaudoDtCadastro { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime LaudoDtRealizacao { get; set; }

        /*Properties utilizadas para insert e update*/
        public int LaudoPacienteId { get; set; }
        public int LaudoConvenioId { get; set; }
        public int LaudoMedicoLaudadorId { get; set; }
        public int LaudoMedicoSolicitanteId { get; set; }
        public int LaudoRitmoId { get; set; }
        public string LaudoConclusoesId { get; set; } /* string contendo id's separados por '-' */

        /*Properties utilizadas nas buscas, para exibir em tela*/
        public PacienteDto LaudoPaciente { get; set; }
        public ConvenioDto LaudoConvenio { get; set; }
        public MedicoDto LaudoMedicoLaudador { get; set; }
        public MedicoDto LaudoMedicoSolicitante { get; set; }
        public RitmoDto LaudoRitmo { get; set; }
        public List<ConclusaoDto> LaudoConclusoes { get; set; }

        /*Properties utilizadas para preenchimento das combos estáticas*/
        public SelectList ListConvenios { get; set; }
        public SelectList ListMedicos { get; set; }
        public SelectList ListRitmos { get; set; }
        public SelectList ListConclusoes { get; set; }
    }
}
