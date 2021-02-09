using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using University_For_All.Models;
using University_For_All.ViewModels;
using System.Data.Entity;
using Microsoft.Owin.Security;

namespace University_For_All.Controllers
{
    public class AdministrationController : Controller
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private readonly RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        private static UserManager<ApplicationUser> UserManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        // GET: Administration

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(CreateRoleViewModels model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                var resulty= roleManager.Create(identityRole);
                if (resulty.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
            }
            Logout();
            return View(model);
        }
        [HttpGet]
        public ActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role=await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                //here i will put a page that handle error
            }
            var model = new EditRoleViewModels
            {
                Id = role.Id,
                RoleName = role.Name

            };
            foreach (var user in UserManeger.Users)
            {
                if (await UserManeger.IsInRoleAsync(user.Id, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
                
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleViewModels EditRole)
        {
            var role = await roleManager.FindByIdAsync(EditRole.Id);
            if (role == null)
            {
                //here i will put a page that handle error
            }
            else
            {
                role.Name = EditRole.RoleName;
                var result =await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
            }
            Logout();
            return View(EditRole);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role==null)
            {
                //here i will put a page that handle error
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
            }
            Logout();
            return View("ListRoles");
        }
        [HttpGet]
        public async Task<ActionResult> EditUsersInRole(string id)
        {
            ViewBag.roleId = id;

            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                //here i will put a page that handle error
            }

            var model = new List<UserRoleViewModels>();

            foreach (var user in UserManeger.Users)
            {
                var userRoleViewModel = new UserRoleViewModels
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await UserManeger.IsInRoleAsync(user.Id, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult>  EditUserInRole(List<UserRoleViewModels> model,string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                //here i will put a page that handle error
            }
            for (int i = 0; i < model.Count; i++)
            {
                var user = await UserManeger.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await UserManeger.IsInRoleAsync(user.Id, role.Name)))
                {
                    result = await UserManeger.AddToRoleAsync(user.Id, role.Name);
                }
                else if (!model[i].IsSelected && await UserManeger.IsInRoleAsync(user.Id, role.Name))
                {
                    result = await UserManeger.RemoveFromRoleAsync(user.Id, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("Edit", new { id = roleId });
                }
            }

            Logout();
            return RedirectToAction("Edit", new { id = roleId });
        }

        public ActionResult manageStudent()
        {
            var students = db.Student.Include(s=>s.Faculty).Include(s=>s.Department).ToList();
            return View(students);
        }
        public ActionResult manageStaff()
        {
            var staff = db.Instructors.Include(s => s.Faculty).Include(s => s.Rank).ToList();
            return View(staff);
        }
        public ActionResult manageFaculty()
        {
            var Faculty = db.Faculty.ToList();
            return View(Faculty);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("login", "Account");
        }
    }
}