using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DangBoWeb.Startup))]
namespace DangBoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
