using System;
using System.ComponentModel.DataAnnotations;

namespace AppServices.Dtos
{
    public class ConclusaoDto
    {
        public int ConclusaoId { get; set; }
        public string ConclusaoCodigo { get; set; }
        public string ConclusaoDescricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ConclusaoDtCadastro { get; set; }
    }
}
