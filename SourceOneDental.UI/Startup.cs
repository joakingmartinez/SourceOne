using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SourceOneDental.UI.Startup))]
namespace SourceOneDental.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
