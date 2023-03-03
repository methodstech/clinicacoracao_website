using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;

namespace Data.Repositories
{
    internal class ConclusaoRepository : RepositoryBase, Domain.Repositories.IConclusaoRepository
    {
        public Conclusao Create(Conclusao obj)
        {
            obj.ConclusaoId = Connection.QueryFirst<int>("exec conclusao_i @ConclusaoCodigo, @ConclusaoDescricao", obj);
            return obj;
        }

        public bool Delete(int id)
        {
            int affectedRows = Connection.Execute("exec conclusao_d @ConclusaoId", new { ConclusaoId = id });
            return affectedRows > 0;
        }

        public Conclusao GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Conclusao>("exec conclusao_g @ConclusaoId", new { ConclusaoId = id });
            return result;
        }

        public IEnumerable<Conclusao> List(ConclusaoFilter filter)
        {
            var result = Connection.Query<Conclusao>("exec conclusao_l @ConclusaoCodigo, @ConclusaoDescricao, @LaudoId", filter);
            return result;
        }

        public bool Update(Conclusao obj)
        {
            var affectedRows = Connection.Execute("exec conclusao_u @ConclusaoId, @ConclusaoCodigo, @ConclusaoDescricao", obj);
            return affectedRows > 0;
        }
    }
}
