using System;
using System.ComponentModel.DataAnnotations;

namespace AppServices.Dtos
{
    public class RitmoDto
    {
        public int RitmoId { get; set; }
        public string RitmoCodigo { get; set; }
        public string RitmoDescricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtCadastro { get; set; }
    }
}
