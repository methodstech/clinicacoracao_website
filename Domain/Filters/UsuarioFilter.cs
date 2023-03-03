using System;

namespace Domain.Filters
{
    public class UsuarioFilter
    {
        public int? UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioNomeUsuario { get; set; }
        public string UsuarioSenha { get; set; }
        public string UsuarioEmail { get; set; }
        public DateTime? UsuarioDtCadastro { get; set; }
    }
}
