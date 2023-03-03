using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;

namespace Data.Repositories
{
    internal class RitmoRepository : RepositoryBase, Domain.Repositories.IRitmoRepository
    {
        public Ritmo Create(Ritmo obj)
        {
            obj.RitmoId = Connection.QueryFirst<int>("exec ritmo_i @RitmoCodigo, @RitmoDescricao", obj);
            return obj;
        }

        public bool Delete(int id)
        {
            int affectedRows = Connection.Execute("exec ritmo_d @RitmoId", new { RitmoId = id });
            return affectedRows > 0;
        }

        public Ritmo GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Ritmo>("exec ritmo_g @RitmoId", new { RitmoId = id });
            return result;
        }

        public IEnumerable<Ritmo> List(RitmoFilter filter)
        {
            var result = Connection.Query<Ritmo>("exec ritmo_l @RitmoCodigo, @RitmoDescricao", filter);
            return result;
        }

        public bool Update(Ritmo obj)
        {
            var affectedRows = Connection.Execute("exec ritmo_u @RitmoId, @RitmoCodigo, @RitmoDescricao", obj);
            return affectedRows > 0;
        }
    }
}
