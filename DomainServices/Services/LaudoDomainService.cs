using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using System.Linq;
using System.Data;

namespace DomainServices.Services
{
    internal class LaudoDomainService : Interfaces.ILaudoDomainService
    {
        private readonly ILaudoRepository _repository;
        private readonly IPacienteRepository _repositoryPaciente;
        private readonly IConvenioRepository _repositoryConvenio;
        private readonly IMedicoRepository _repositoryMedico;
        private readonly IRitmoRepository _repositoryRitmo;
        private readonly IConclusaoRepository _repositoryConclusao;

        public LaudoDomainService(ILaudoRepository repository, IPacienteRepository repositoryPaciente, 
            IConvenioRepository repositoryConvenio, IMedicoRepository repositoryMedico, IRitmoRepository repositoryRitmo,
            IConclusaoRepository repositoryConclusao)
        {
            _repository = repository;
            _repositoryPaciente = repositoryPaciente;
            _repositoryConvenio = repositoryConvenio;
            _repositoryMedico = repositoryMedico;
            _repositoryRitmo = repositoryRitmo;
            _repositoryConclusao = repositoryConclusao;
        }

        public Laudo Create(Laudo laudo)
        {
            return _repository.Create(laudo);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Laudo GetById(int id)
        {
            Laudo laudo = _repository.GetById(id);
            laudo.LaudoPaciente = _repositoryPaciente.GetById(laudo.LaudoPacienteId);
            laudo.LaudoConvenio = _repositoryConvenio.GetById(laudo.LaudoConvenioId);
            laudo.LaudoMedicoLaudador = _repositoryMedico.GetById(laudo.LaudoMedicoLaudadorId);
            laudo.LaudoMedicoSolicitante = _repositoryMedico.GetById(laudo.LaudoMedicoSolicitanteId);
            laudo.LaudoRitmo = _repositoryRitmo.GetById(laudo.LaudoRitmoId);
            laudo.LaudoConclusoes = _repositoryConclusao.List(new ConclusaoFilter { LaudoId = id });
            return laudo;
        }

        public IEnumerable<Laudo> List(LaudoFilter filter)
        {
            List<Laudo> laudos = _repository.List(filter).ToList();
            //foreach(Laudo l in laudos)
            //{

            //    l.LaudoPaciente = _repositoryPaciente.GetById(l.LaudoPacienteId);
            //    l.LaudoConvenio = _repositoryConvenio.GetById(l.LaudoConvenioId);
            //    l.LaudoMedicoLaudador = _repositoryMedico.GetById(l.LaudoMedicoLaudadorId);
            //    l.LaudoMedicoSolicitante = _repositoryMedico.GetById(l.LaudoMedicoSolicitanteId);
            //    l.LaudoRitmo = _repositoryRitmo.GetById(l.LaudoRitmoId);
            //}

            return laudos;
        }

        public DataTable ListDataTable(LaudoFilter filter)
        {
            return _repository.ListDataTable(filter);
        }

        public bool Update(Laudo laudo)
        {
            return _repository.Update(laudo);
        }
    }
}
