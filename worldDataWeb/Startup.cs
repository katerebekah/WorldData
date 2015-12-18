using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(worldDataWeb.Startup))]
namespace worldDataWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
