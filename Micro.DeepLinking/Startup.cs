using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Micro.DeepLinking.Startup))]
namespace Micro.DeepLinking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
