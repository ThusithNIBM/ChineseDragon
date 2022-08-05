using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChineseDragon.Startup))]
namespace ChineseDragon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
