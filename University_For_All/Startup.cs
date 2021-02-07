using System.Web.WebSockets;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using University_For_All.Models;

[assembly: OwinStartupAttribute(typeof(University_For_All.Startup))]
namespace University_For_All
{
    public partial class Startup
    {
        ApplicationDbContext db =new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
