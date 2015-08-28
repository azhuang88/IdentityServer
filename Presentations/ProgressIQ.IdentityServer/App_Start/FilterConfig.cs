using System.Web;
using System.Web.Mvc;
using IdentityServer.Repositories;
using ProgressIQ.IdentityServer.Web.GlobalFilter;

namespace ProgressIQ.IdentityServer.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IConfigurationRepository configuration)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalViewModelFilter());
            if (!configuration.Global.DisableSSL)
            {
                filters.Add(new SslRedirectFilter(configuration.Global.HttpsPort, configuration.Global.PublicHostName));
            }
            filters.Add(new InitialConfigurationFilter());
        }
    }
}
