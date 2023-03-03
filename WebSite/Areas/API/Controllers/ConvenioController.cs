using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebSite.Areas.API.Controllers
{
    public class ConvenioController : ApiController
    {
        private readonly IConvenioAppService _appService;

        public ConvenioController(IConvenioAppService appService)
        {
            _appService = appService;
        }

        // GET: api/Convenio
        public IEnumerable<ConvenioDto> Get([FromBody]ConvenioFilterDto filter)
        {
            return _appService.List(filter);
        }

        // GET: api/Convenio/5
        public ConvenioDto Get(int id)
        {
            return _appService.GetById(id);
        }

        // POST: api/Convenio
        public ConvenioDto Post([FromBody]ConvenioDto value)
        {
            return _appService.Create(value);
        }

        // PUT: api/Convenio/5
        public bool Put([FromBody]ConvenioDto value)
        {
            return _appService.Update(value);
        }

        // DELETE: api/Convenio/5
        public bool Delete(int id)
        {
            return _appService.Delete(id);
        }
    }
}
