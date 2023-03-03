using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebSite.Areas.Laudo.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioAppService _appService;

        public ContaController(IUsuarioAppService appService)
        {
            _appService = appService;
        }

        // GET: Conta/Login
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Create", "Laudo");
            }
            return View();
        }

        // POST: Conta/Login
        [HttpPost]
        public ActionResult Login(UsuarioDto model, string returnUrl)
        {
            try
            {
                UsuarioFilterDto filter = new UsuarioFilterDto { UsuarioNomeUsuario = model.UsuarioNomeUsuario };
                var listUsuario = _appService.List(filter).ToList();
                if (listUsuario.Count == 0)
                {
                    TempData["error"] = "Usuário não encontrado";
                    return View(model);
                }

                var usuario = listUsuario[0];
                if (usuario.UsuarioSenha != model.UsuarioSenha)
                {
                    TempData["error"] = "Senha inválida";
                    return View(model);
                }

                CriarSessao(model, false);

                //se returnUrl não for null, então usuário tentou acessar página que necessitava autenticação mas não estava logado,
                //e como chegou aqui, ele fez login. Logo, devo retornar para a página que ele tentou acessar antes.
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                //caso contrário retorna para Laudo/Create
                return RedirectToAction("Create", "Laudo");
            }
            catch(Exception exception)
            {
                // ignored
                TempData["error"] = exception.Message;
            }
            return View();
        }

        // GET: Conta/NovaSenha
        public ActionResult NovaSenha()
        {
            return View();
        }

        // GET: Conta/RecuperarSenha
        public ActionResult RecuperarSenha()
        {
            return View();
        }

        private void CriarSessao(UsuarioDto m, bool lembrarSenha)
        {
            //Cria ticket de login para este usuário
            CreateAuthorizeTicket(m.UsuarioEmail + "|" + m.UsuarioId + "|" + m.UsuarioNomeUsuario, "roles", lembrarSenha);
        }

        /// <summary>
        ///     Cria ticket de login para usuário.
        /// </summary>
        /// <param name="username">Nome de usuário de quem está fazendo login.</param>
        /// <param name="roles">Regras em que o</param>
        /// <param name="lembrar">Indica se cookie deve ser mantido no PC.</param>
        public void CreateAuthorizeTicket(string username, string roles, bool lembrar)
        {
            DateTime utcExpires = lembrar ? DateTime.Now.AddDays(5) : DateTime.Now.AddMinutes(20);

            var authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, utcExpires, // validade 30 min
                lembrar, // Se você deixar true, o cookie ficará no PC do usuário
                roles, "/");

            string encrypetedTicket = FormsAuthentication.Encrypt(authTicket);
            FormsAuthentication.SetAuthCookie(encrypetedTicket, lembrar);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));

            if (lembrar)
            {
                cookie.Expires = authTicket.Expiration;
            }

            Response.Cookies.Add(cookie);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}