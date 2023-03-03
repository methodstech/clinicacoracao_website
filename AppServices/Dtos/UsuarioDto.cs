using System;
using System.ComponentModel.DataAnnotations;

namespace AppServices.Dtos
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioNomeUsuario { get; set; }
        public string UsuarioSenha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string UsuarioEmail { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UsuarioDtCadastro { get; set; }
    }
}
