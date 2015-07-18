using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchAreaWeb.Startup))]
namespace SearchAreaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
