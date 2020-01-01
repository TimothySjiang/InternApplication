using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternApplication.Startup))]
namespace InternApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
