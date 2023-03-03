using System.Web.Http;

namespace WebSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    "DefaultApi",
            //    "API/{controller}/{id}",
            //    new { id = RouteParameter.Optional }
            //);

        }
    }
}
