using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChineseDragonMobile.Startup))]
namespace ChineseDragonMobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
