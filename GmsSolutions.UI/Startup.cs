using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GmsSolutions.UI.Startup))]
namespace GmsSolutions.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
