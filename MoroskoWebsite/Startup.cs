using Microsoft.Owin;
using MoroskoWebsite.Controllers;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoroskoWebsite.Startup))]
namespace MoroskoWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
