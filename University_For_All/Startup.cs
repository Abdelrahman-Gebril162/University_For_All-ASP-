using System;
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
        private readonly RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("student"));
            roleManager.Create(new IdentityRole("professor"));
            Faculty f =new Faculty()
            {
                fc_name = "Master",
                fc_description = "this is master faculty represent University at all",
                fc_created_at = Convert.ToDateTime("1-1-2000"),
                fc_levels_num = 5,
                fc_logo = "~/Upload/defaultImage/Faculty_default.png",
                fc_spicial_year = 2
            };
            if (db.Faculty.SingleOrDefault(fc=>fc.fc_name=="Master")==null)
            {
                db.Faculty.Add(f);
                db.SaveChanges();
            }
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
                    Facultyid = db.Faculty.Single(fc=>fc.fc_name=="Master").id
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
                    UserManeger.AddToRole(newUser.Id, "professor");
                }
            }
            
           
        }
    }

    
}
