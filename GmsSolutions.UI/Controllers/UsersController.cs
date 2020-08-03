using GmsSolutions.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GmsSolutions.UI.Controllers
{
    [Authorize(Users = "csergio@silva.com") ]
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManeger.Users.ToList();
            var usersView = new List<UserView>();

            foreach (var user in users)
            {
                var userView = new UserView()
                {
                    Email = user.Email,
                    Nome = user.UserName,
                    UserId = user.Id
                };

                usersView.Add(userView);
            }
            return View(usersView);
        }
        public ActionResult Roles(string userId)
        {
            var userManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManeger.Users.ToList();
            var user = users.Find(u => u.Id == userId);

            var roleManeger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManeger.Roles.ToList();
            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new RoleView()
                {
                    RoleId = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }

            var userView = new UserView()
            {
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id,
                Roles = rolesView
            };

            return View(userView);
        }
        public ActionResult AddRoles(string userId)
        {
            var userManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManeger.Users.ToList();
            var user = users.Find(u => u.Id == userId);
            var userView = new UserView()
            {
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id
            };
            var roleManeger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));      
            var list = roleManeger.Roles.ToList();
            list.Add(new IdentityRole {Id ="" , Name = "[Selecione uma Permissão !]" });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleId = new SelectList(list, "Id", "Name");

           
            return View(userView);
        }
        [HttpPost]
        public ActionResult AddRoles(string userId, FormCollection collection)
        {
            var roleManeger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var users = userManeger.Users.ToList();
            var user = users.Find(u => u.Id == userId);
            var userView = new UserView()
            {
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id
            };

            var roleId = Request["RoleId"];
            if (string.IsNullOrEmpty(roleId))
            {
                var list = roleManeger.Roles.ToList();
                list.Add(new IdentityRole { Id = "", Name = " [Selecione uma Permissão ! ]" });
                list = list.OrderBy(r => r.Name).ToList();
                ViewBag.RoleId = new SelectList(list, "Id", "Name");

                ViewBag.Error = " Uma Permissão Precisa ser Selecionada !!!  ";
                return View(userView);
            }
            
        
            var roles = roleManeger.Roles.ToList();
            var role = roles.Find(r => r.Id == roleId); 
            if (!userManeger.IsInRole(userId, role.Name))
            {
                userManeger.AddToRole(userId, role.Name);
            }

            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new RoleView()
                {
                    RoleId = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }
             userView = new UserView()
            {
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id,
                Roles = rolesView
            };

            return View("Roles", userView);
        }
        public ActionResult Delete(string userId, string roleId)        
        {
            var roleManeger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManeger.Roles.ToList();
            var role = roles.Find(r => r.Id == roleId);
            

            var userManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManeger.Users.ToList().Find(u => u.Id == userId);

            if (userManeger.IsInRole(users.Id, role.Name))
            {
                userManeger.RemoveFromRoles(users.Id, role.Name);
            }      

            var rolesView = new List<RoleView>();

            foreach (var item in users.Roles) 
            {
                role = roles.Find(r => r.Id == item.RoleId); 
                var roleView = new RoleView()
                {
                    RoleId = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }

           var userView = new UserView()
            {
                Email = users.Email,
                Nome = users.UserName,
                UserId = users.Id,
                Roles = rolesView
            };

            return View("Roles", userView);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
   
} 