using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;

namespace Data.Repositories
{
    internal class UsuarioRepository : RepositoryBase, Domain.Repositories.IUsuarioRepository
    {
        public Usuario Create(Usuario usuario)
        {
            usuario.UsuarioId = Connection.QueryFirst<int>("exec usuario_i @UsuarioNome, @UsuarioNomeUsuario, @UsuarioSenha, @UsuarioEmail", usuario);
            return usuario;
        }

        public bool Delete(int id)
        {
            int affectedRows = Connection.Execute("exec usuario_d @UsuarioId", new { UsuarioId = id });
            return affectedRows > 0;
        }

        public Usuario GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Usuario>("exec usuario_g @UsuarioId", new { UsuarioId = id });
            return result;
        }

        public IEnumerable<Usuario> List(UsuarioFilter filter)
        {
            var result = Connection.Query<Usuario>("exec usuario_l @UsuarioNome, @UsuarioNomeUsuario", filter);
            return result;
        }

        public bool Update(Usuario usuario)
        {
            var affectedRows = Connection.Execute("exec usuario_u @UsuarioId, @UsuarioNome, @UsuarioNomeUsuario, @UsuarioSenha, @UsuarioEmail", usuario);
            return affectedRows > 0;
        }
    }
}
