using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WardrobeProject4.Startup))]
namespace WardrobeProject4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
