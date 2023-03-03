using AppServices.Dtos;
using AppServices.Filters;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IPacienteAppService
    {
        PacienteDto Create(PacienteDto paciente);
        IEnumerable<PacienteDto> List(PacienteFilterDto filter);
        PacienteDto GetById(int id);
        bool Update(PacienteDto paciente);
        bool Delete(int id);
    }
}
