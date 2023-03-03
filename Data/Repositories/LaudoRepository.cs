using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repositories
{
    internal class LaudoRepository : RepositoryBase, Domain.Repositories.ILaudoRepository
    {
        public Laudo Create(Laudo obj)
        {
            obj.LaudoId = Connection.QueryFirst<int>("exec laudo_i @LaudoPacienteId, @LaudoConvenioId, " +
                "@LaudoMedicoLaudadorId, @LaudoMedicoSolicitanteId, @LaudoRitmoId, @LaudoComplemento, " +
                "@LaudoConclusoesId, @LaudoDtRealizacao", obj);
            return obj;
        }

        public bool Delete(int id)
        {
            int affectedRows = Connection.Execute("exec laudo_d @LaudoId", new { LaudoId = id });
            return affectedRows > 0;
        }

        public Laudo GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Laudo>("exec laudo_g @LaudoId", new { LaudoId = id });
            return result;
        }

        public IEnumerable<Laudo> List(LaudoFilter filter)
        {
            var query = "exec laudo_l @LaudoPacienteId, @LaudoConvenioId, @LaudoMedicoLaudadorId, " +
                        "@LaudoMedicoSolicitanteId, @LaudoRitmoId, @LaudoComplemento, @LaudoDtInicial, @LaudoDtFinal";
            var result = Connection.Query<Laudo, Paciente, Convenio, Medico, Medico, Ritmo, Laudo>(query, (laudo, paciente, convenio, medicoL, medicoS, ritmo) =>
                {
                    laudo.LaudoPaciente = paciente;
                    laudo.LaudoConvenio = convenio;
                    laudo.LaudoMedicoLaudador = medicoL;
                    laudo.LaudoMedicoSolicitante = medicoS;
                    laudo.LaudoRitmo = ritmo;
                    return laudo;
                },
            filter,
            splitOn: "PacienteId, ConvenioId, MedicoId, MedicoId, RitmoId");
            return result;
        }

        public DataTable ListDataTable(LaudoFilter filter)
        {
            using(SqlCommand command = new SqlCommand())
            {
                command.Connection = (SqlConnection) Connection;
                command.Connection.Open();
                command.CommandText = "laudo_excel_l";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@LaudoPacienteId", SqlDbType.Int).Value = filter.LaudoPacienteId;
                command.Parameters.Add("@LaudoConvenioId", SqlDbType.Int).Value = filter.LaudoConvenioId;
                command.Parameters.Add("@LaudoMedicoLaudadorId", SqlDbType.Int).Value = filter.LaudoMedicoLaudadorId;
                command.Parameters.Add("@LaudoMedicoSolicitanteId", SqlDbType.Int).Value = filter.LaudoMedicoSolicitanteId;
                command.Parameters.Add("@LaudoRitmoId", SqlDbType.Int).Value = filter.LaudoRitmoId;
                command.Parameters.Add("@LaudoDtInicial", SqlDbType.DateTime).Value = filter.LaudoDtInicial;
                command.Parameters.Add("@LaudoDtFinal", SqlDbType.DateTime).Value = filter.LaudoDtFinal;

                foreach (IDataParameter param in command.Parameters)
                {
                    if (param.Value == null) param.Value = DBNull.Value;
                }

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public bool Update(Laudo obj)
        {
            var affectedRows = Connection.Execute("exec laudo_u @LaudoId, @LaudoPacienteId, @LaudoConvenioId, " +
                "@LaudoMedicoLaudadorId, @LaudoMedicoSolicitanteId, @LaudoRitmoId, @LaudoComplemento, @LaudoConclusoesId, " +
                "@LaudoDtRealizacao", obj);
            return affectedRows > 0;
        }
    }
}
