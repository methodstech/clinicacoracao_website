using System;
using System.ComponentModel.DataAnnotations;

namespace AppServices.Dtos
{
    public class ConvenioDto
    {
        public int ConvenioId { get; set; }
        public string ConvenioNome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ConvenioDtCadastro { get; set; }
    }
}
