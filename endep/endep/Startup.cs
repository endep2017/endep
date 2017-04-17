using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(endep.Startup))]
namespace endep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
