using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BT.Stage.SGIMI.UserInterface.WebApp.Startup))]
namespace BT.Stage.SGIMI.UserInterface.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
