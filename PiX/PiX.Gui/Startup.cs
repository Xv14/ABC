using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PiX.Gui.Startup))]
namespace PiX.Gui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
