using System.Web.Mvc;

namespace WebSite.Helper
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.Controller.TempData["msg_error"] = "Você não está logado ou não tem permissão para acessar a página.";
        }
    }
}