using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(University_For_All.Startup))]
namespace University_For_All
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
