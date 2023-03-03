using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebSite.Areas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _appService;

        public UsuarioController(IUsuarioAppService appService)
        {
            _appService = appService;
        }

        // GET: api/Usuario
        public IEnumerable<UsuarioDto> Get(UsuarioFilterDto filter)
        {
            return _appService.List(filter);
        }

        // GET: api/Usuario/5
        public UsuarioDto Get(int id)
        {
            return _appService.GetById(id);
        }

        // POST: api/Usuario
        public UsuarioDto Post([FromBody]UsuarioDto usuario)
        {
            return _appService.Create(usuario);
        }

        // PUT: api/Usuario/5
        public bool Put([FromBody]UsuarioDto usuario)
        {
            return _appService.Update(usuario);
        }

        // DELETE: api/Usuario/5
        public bool Delete(int id)
        {
            return _appService.Delete(id);
        }
    }
}
