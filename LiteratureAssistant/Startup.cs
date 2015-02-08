using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(LiteratureAssistant.Startup))]
namespace LiteratureAssistant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureAuth(app);

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
