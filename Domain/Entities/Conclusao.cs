using System;

namespace Domain.Entities
{
    public class Conclusao
    {
        public int ConclusaoId { get; set; }
        public string ConclusaoCodigo { get; set; }
        public string ConclusaoDescricao { get; set; }
        public DateTime ConclusaoDtCadastro { get; set; }
    }
}
