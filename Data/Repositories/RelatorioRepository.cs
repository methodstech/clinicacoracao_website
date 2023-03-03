using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Dapper;

namespace Data.Repositories
{
    internal class RelatorioRepository : RepositoryBase, Domain.Repositories.IRelatorioRepository
    {
        public RelatorioHistoricoPaciente Create(RelatorioHistoricoPaciente obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RelatorioHistoricoPaciente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RelatorioHistoricoPaciente> List(RelatorioHistoricoPacienteFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RelatorioHistoricoPaciente> RelatorioHistoricoPaciente(RelatorioHistoricoPacienteFilter filter)
        {
            var result = Connection.Query<RelatorioHistoricoPaciente>("exec historicoporpaciente_r @PacienteId", filter);
            return result;
        }

        public RelatorioRitmoConclusao RelatorioRitmoConclusao(RelatorioRitmoConclusaoFilter filter)
        {
            var result = Connection.QueryFirstOrDefault<RelatorioRitmoConclusao>("exec percporritmoeconclusao_r @RitmoId, @ConclusaoId, @DtInicial, @DtFinal", filter);
            return result;
        }

        public IEnumerable<RelatorioRitmoConclusaoDetalhes> RelatorioRitmoConclusaoDetalhes(RelatorioRitmoConclusaoFilter filter)
        {
            var result = Connection.Query<RelatorioRitmoConclusaoDetalhes>("exec percporritmoeconclusaodetalhamento_r @RitmoId, @ConclusaoId, @DtInicial, @DtFinal", filter);
            return result;
        }

        public bool Update(RelatorioHistoricoPaciente obj)
        {
            throw new NotImplementedException();
        }
    }
}
