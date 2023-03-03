using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebSite.Areas.API.Controllers
{
    public class LaudoController : ApiController
    {
        private readonly ILaudoAppService _appService;

        public LaudoController(ILaudoAppService appService)
        {
            _appService = appService;
        }

        // GET: api/Laudo
        public IEnumerable<LaudoDto> Get([FromBody]LaudoFilterDto filter)
        {
            return _appService.List(filter);
        }

        // GET: api/Laudo/5
        public LaudoDto Get(int id)
        {
            return _appService.GetById(id);
        }

        // POST: api/Laudo
        public LaudoDto Post([FromBody]LaudoDto value)
        {
            return _appService.Create(value);
        }

        // PUT: api/Laudo/5
        public bool Put(int id, [FromBody]LaudoDto value)
        {
            return _appService.Update(value);
        }

        // DELETE: api/Laudo/5
        public bool Delete(int id)
        {
            return _appService.Delete(id);
        }
    }
}
