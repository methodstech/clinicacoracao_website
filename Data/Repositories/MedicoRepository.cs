using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;

namespace Data.Repositories
{
    internal class MedicoRepository : RepositoryBase, Domain.Repositories.IMedicoRepository
    {
        public Medico Create(Medico obj)
        {
            obj.MedicoId = Connection.QueryFirst<int>("exec medico_i @MedicoNome, @MedicoCRM", obj);
            return obj;
        }

        public bool Delete(int id)
        {
            int affectedRows = Connection.Execute("exec medico_d @MedicoId", new { MedicoId = id });
            return affectedRows > 0;
        }

        public Medico GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Medico>("exec medico_g @MedicoId", new { MedicoId = id });
            return result;
        }

        public IEnumerable<Medico> List(MedicoFilter filter)
        {
            var result = Connection.Query<Medico>("exec medico_l @MedicoNome, @MedicoCRM", filter);
            return result;
        }

        public bool Update(Medico obj)
        {
            var affectedRows = Connection.Execute("exec medico_u @MedicoId, @MedicoNome, @MedicoCRM", obj);
            return affectedRows > 0;
        }
    }
}
