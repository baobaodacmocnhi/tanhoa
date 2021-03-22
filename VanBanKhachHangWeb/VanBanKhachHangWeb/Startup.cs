using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VanBanKhachHangWeb.Startup))]
namespace VanBanKhachHangWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
