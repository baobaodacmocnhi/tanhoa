using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaoCaoWeb.Startup))]
namespace BaoCaoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
