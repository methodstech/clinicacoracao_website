using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebSite.Areas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RitmoController : ApiController
    {
        private readonly IRitmoAppService _appService;

        public RitmoController(IRitmoAppService appService)
        {
            _appService = appService;
        }

        // GET: api/Ritmo
        public IEnumerable<RitmoDto> Get([FromBody] RitmoFilterDto filter)
        {
            return _appService.List(filter);
        }

        // GET: api/Ritmo/5
        public RitmoDto Get(int id)
        {
            return _appService.GetById(id);
        }

        // POST: api/Ritmo
        public RitmoDto Post([FromBody]RitmoDto value)
        {
            return _appService.Create(value);
        }

        // PUT: api/Ritmo/5
        public bool Put([FromBody]RitmoDto value)
        {
            return _appService.Update(value);
        }

        // DELETE: api/Ritmo/5
        public bool Delete(int id)
        {
            return _appService.Delete(id);
        }
    }
}
