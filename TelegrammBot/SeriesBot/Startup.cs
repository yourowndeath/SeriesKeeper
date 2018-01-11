using System.Web.Http;
using Owin;

namespace SeriesBot
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();

            configuration.Routes.MapHttpRoute("WebHook", "{controller}");

            app.UseWebApi(configuration);
        }
    }
}
