using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebSite.Areas.API.Controllers
{
    public class MedicoController : ApiController
    {
        private readonly IMedicoAppService _appService;

        public MedicoController(IMedicoAppService appService)
        {
            _appService = appService;
        }

        // GET: api/Medico
        public IEnumerable<MedicoDto> Get([FromBody]MedicoFilterDto filter)
        {
            return _appService.List(filter);
        }

        // GET: api/Medico/5
        public MedicoDto Get(int id)
        {
            return _appService.GetById(id);
        }

        // POST: api/Medico
        public MedicoDto Post([FromBody]MedicoDto value)
        {
            return _appService.Create(value);
        }

        // PUT: api/Medico/5
        public bool Put([FromBody]MedicoDto value)
        {
            return _appService.Update(value);
        }

        // DELETE: api/Medico/5
        public bool Delete(int id)
        {
            return _appService.Delete(id);
        }
    }
}
