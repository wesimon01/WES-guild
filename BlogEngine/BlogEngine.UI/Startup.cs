using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogEngine.UI.Startup))]
namespace BlogEngine.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
