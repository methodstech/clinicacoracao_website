using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebSite.Areas.API.Controllers
{
    public class PacienteController : ApiController
    {
        private readonly IPacienteAppService _appService;

        public PacienteController(IPacienteAppService appService)
        {
            _appService = appService;
        }

        // GET: api/Paciente
        public IEnumerable<PacienteDto> Get([FromBody]PacienteFilterDto filter)
        {
            return _appService.List(filter);
        }

        // GET: api/Paciente/5
        public PacienteDto Get(int id)
        {
            return _appService.GetById(id);
        }

        // POST: api/Paciente
        public PacienteDto Post([FromBody]PacienteDto value)
        {
            return _appService.Create(value);
        }

        // PUT: api/Paciente/5
        public bool Put([FromBody]PacienteDto value)
        {
            return _appService.Update(value);
        }

        // DELETE: api/Paciente/5
        public bool Delete(int id)
        {
            return _appService.Delete(id);
        }
    }
}
