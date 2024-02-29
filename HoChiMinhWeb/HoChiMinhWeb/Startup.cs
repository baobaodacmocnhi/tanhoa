using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HoChiMinhWeb.Startup))]
namespace HoChiMinhWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
