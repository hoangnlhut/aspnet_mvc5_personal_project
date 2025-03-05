using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1WelcomeApp.Startup))]
namespace _1WelcomeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
