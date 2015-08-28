using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgressIQ.IdentityServer.Web.Startup))]
namespace ProgressIQ.IdentityServer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
