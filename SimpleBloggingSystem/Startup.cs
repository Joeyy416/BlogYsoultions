using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleBloggingSystem.Startup))]
namespace SimpleBloggingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
