using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebSite.Areas.API.Controllers
{
    public class ConclusaoController : ApiController
    {
        private readonly IConclusaoAppService _appService;

        public ConclusaoController(IConclusaoAppService appService)
        {
            _appService = appService;
        }

        // GET: api/Conclusao
        public IEnumerable<ConclusaoDto> Get([FromBody]ConclusaoFilterDto filter)
        {
            return _appService.List(filter);
        }

        // GET: api/Conclusao/5
        public ConclusaoDto Get(int id)
        {
            return _appService.GetById(id);
        }

        // POST: api/Conclusao
        public ConclusaoDto Post([FromBody]ConclusaoDto value)
        {
            return _appService.Create(value);
        }

        // PUT: api/Conclusao/5
        public bool Put([FromBody]ConclusaoDto value)
        {
            return _appService.Update(value);
        }

        // DELETE: api/Conclusao/5
        public bool Delete(int id)
        {
            return _appService.Delete(id);
        }
    }
}
