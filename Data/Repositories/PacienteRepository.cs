using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;

namespace Data.Repositories
{
    internal class PacienteRepository : RepositoryBase, Domain.Repositories.IPacienteRepository
    {
        public Paciente Create(Paciente obj)
        {
            obj.PacienteId = Connection.QueryFirst<int>("exec paciente_i @PacienteNome, @PacienteDataNascimento", obj);
            return obj;
        }

        public bool Delete(int id)
        {
            int affectedRows = Connection.Execute("exec paciente_d @PacienteId", new { PacienteId = id });
            return affectedRows > 0;
        }

        public Paciente GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Paciente>("exec paciente_g @PacienteId", new { PacienteId = id });
            return result;
        }

        public IEnumerable<Paciente> List(PacienteFilter filter)
        {
            var result = Connection.Query<Paciente>("exec paciente_l @PacienteNome, @PacienteDataNascimento", filter);
            return result;
        }

        public bool Update(Paciente obj)
        {
            var affectedRows = Connection.Execute("exec paciente_u @PacienteId, @PacienteNome, @PacienteDataNascimento", obj);
            return affectedRows > 0;
        }
    }
}
