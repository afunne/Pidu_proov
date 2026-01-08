using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pidu_proov.Startup))]
namespace Pidu_proov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
