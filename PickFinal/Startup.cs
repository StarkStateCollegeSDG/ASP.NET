using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PickFinal.Startup))]
namespace PickFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
