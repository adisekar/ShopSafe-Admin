using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopSafe.Startup))]
namespace ShopSafe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
