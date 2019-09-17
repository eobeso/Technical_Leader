using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Technical_Leader.Startup))]
namespace Technical_Leader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
