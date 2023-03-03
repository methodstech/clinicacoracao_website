using System;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace WebSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Mappings.AutoMapperConfiguration.Initialize();
        }

        private void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User == null)
            {
                return;
            }

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return;
            }

            if (!(HttpContext.Current.User.Identity is FormsIdentity))
            {
                return;
            }

            var id = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string userData = ticket.UserData;
            string[] roles = userData.Split(',');
            HttpContext.Current.User = new GenericPrincipal(id, roles);
        }
    }
}
