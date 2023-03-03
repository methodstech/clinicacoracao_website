using Domain.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IPacienteDomainService
    {
        Paciente Create(Paciente paciente);
        IEnumerable<Paciente> List(PacienteFilter filter);
        Paciente GetById(int id);
        bool Update(Paciente paciente);
        bool Delete(int id);
    }
}
