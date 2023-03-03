using System;

namespace Domain.Entities
{
    public class Ritmo
    {
        public int RitmoId { get; set; }
        public string RitmoCodigo { get; set; }
        public string RitmoDescricao { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
