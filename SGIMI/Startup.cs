using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGIMI.Startup))]
namespace SGIMI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
