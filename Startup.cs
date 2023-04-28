using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileStoreV3.Startup))]
namespace MobileStoreV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
