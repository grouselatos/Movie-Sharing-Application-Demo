using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WatchAuth.Startup))]
namespace WatchAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
