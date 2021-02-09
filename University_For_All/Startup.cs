using System.Linq;
using System.Web.ApplicationServices;
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
        static ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> UserManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            if (db.Instructors.SingleOrDefault(i=>i.ints_email== "admin@gmail.com") ==null)
            {
                Instructor instructor = new Instructor()
                {
                    ints_fname = "Master",
                    inst_lname = "admin",
                    ints_email = "admin@gmail.com",
                    inst_password = "111111",
                    inst_confirmPassword = "111111",
                    inst_picture = "~/Upload/defaultImage/staff.png",
                    Rankid = 1,
                    Facultyid = 1008
                };
                db.Instructors.Add(instructor);
                db.SaveChanges();
                ApplicationUser newUser = new ApplicationUser()
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                };
                var check = UserManeger.Create(newUser, "111111");
                if (check.Succeeded)
                {
                    UserManeger.AddToRole(newUser.Id, "admin");
                    UserManeger.AddToRole(newUser.Id, "instructor");
                }
            }
            
           
        }
    }

    
}
