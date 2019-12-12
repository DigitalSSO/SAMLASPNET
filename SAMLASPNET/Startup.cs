using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAMLASPNET.Startup))]
namespace SAMLASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
