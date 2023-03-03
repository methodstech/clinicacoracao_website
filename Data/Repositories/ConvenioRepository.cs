using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;

namespace Data.Repositories
{
    internal class ConvenioRepository : RepositoryBase, Domain.Repositories.IConvenioRepository
    {
        public Convenio Create(Convenio obj)
        {
            obj.ConvenioId = Connection.QueryFirst<int>("exec convenio_i @ConvenioNome", obj);
            return obj;
        }

        public bool Delete(int id)
        {
            int affectedRows = Connection.Execute("exec convenio_d @ConvenioId", new { ConvenioId = id });
            return affectedRows > 0;
        }

        public Convenio GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Convenio>("exec convenio_g @ConvenioId", new { ConvenioId = id });
            return result;
        }

        public IEnumerable<Convenio> List(ConvenioFilter filter)
        {
            var result = Connection.Query<Convenio>("exec convenio_l @ConvenioNome", filter);
            return result;
        }

        public bool Update(Convenio obj)
        {
            var affectedRows = Connection.Execute("exec convenio_u @ConvenioId, @ConvenioNome", obj);
            return affectedRows > 0;
        }
    }
}
