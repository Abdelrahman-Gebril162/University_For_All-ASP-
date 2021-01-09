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
            CreateRoles();
            CreateUsers();
            

        }

        public void CreateRoles()
        {
            var roleManager =new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            
            if (!roleManager.RoleExists("admin"))
            {
                role =new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("student"))
            {
                role =new IdentityRole();
                role.Name = "student";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("professor"))
            {
                role = new IdentityRole();
                role.Name = "professor";
                roleManager.Create(role);
            }

        }

        public void CreateUsers()
        {
            var UserManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser user =new ApplicationUser()
            {
                Email = "admin@gmail.com",
                UserName = "admin",
            };
            var check = UserManeger.Create(user, "Admin@111");
            if (check.Succeeded)
            {
                UserManeger.AddToRole(user.Id, "admin");
            }

        }

    }
}
