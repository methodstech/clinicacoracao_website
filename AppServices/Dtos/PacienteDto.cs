using System;
using System.ComponentModel.DataAnnotations;

namespace AppServices.Dtos
{
    public class PacienteDto
    {
        public int PacienteId { get; set; }
        public string PacienteNome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PacienteDataNascimento { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PacienteDtCadastro { get; set; }
    }
}
