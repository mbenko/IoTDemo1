using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PreventPortal.Startup))]
namespace PreventPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
