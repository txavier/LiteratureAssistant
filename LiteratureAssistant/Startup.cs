using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiteratureAssistant.Startup))]
namespace LiteratureAssistant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
