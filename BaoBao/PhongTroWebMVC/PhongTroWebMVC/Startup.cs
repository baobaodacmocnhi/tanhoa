using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhongTroWebMVC.Startup))]
namespace PhongTroWebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
