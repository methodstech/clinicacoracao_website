using System.Web.Mvc;
using WebSite.Helper;

namespace WebSite.Areas.Laudo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index()
        {
            return RedirectToAction("Create", "Laudo");
        }

        // GET: Home/Relatorio
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Relatorio()
        {
            return View();
        }

        // GET: Home/Outros
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Outros()
        {
            return View();
        }
    }
}