using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImovelWeb.Startup.Startup))]
namespace ImovelWeb.Startup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
