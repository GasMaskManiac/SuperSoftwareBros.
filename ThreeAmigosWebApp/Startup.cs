using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThreeAmigosWebApp.Startup))]
namespace ThreeAmigosWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
