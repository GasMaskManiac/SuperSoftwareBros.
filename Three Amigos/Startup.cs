using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Three_Amigos.Startup))]
namespace Three_Amigos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
