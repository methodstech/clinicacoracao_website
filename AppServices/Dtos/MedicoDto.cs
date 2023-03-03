using System;
using System.ComponentModel.DataAnnotations;

namespace AppServices.Dtos
{
    public class MedicoDto
    {
        public int MedicoId { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MedicoDtCadastro { get; set; }
    }
}
