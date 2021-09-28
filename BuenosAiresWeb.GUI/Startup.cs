using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuenosAiresWeb.GUI.Startup))]
namespace BuenosAiresWeb.GUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
