using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DarkSoulsMVC.Startup))]
namespace DarkSoulsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
