using GmsSolutions.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace GmsSolutions.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GmsSolutions.DBreposotorio.Context.LojaContext, DBreposotorio.Migrations.Configurations>());
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperUser(db);
            AddPermSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes); 
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermSuperUser(ApplicationDbContext db)
        {
            var userManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
           var user = userManeger.FindByName("csergio@silva.com");
            var roleManeger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!userManeger.IsInRole(user.Id, "Index"))
            {
                userManeger.AddToRole(user.Id, "Index");
            }
            if (!userManeger.IsInRole(user.Id, "Cadastrar"))
            {
                userManeger.AddToRole(user.Id, "Cadastrar");
            }
            if (!userManeger.IsInRole(user.Id, "Editar"))
            {
                userManeger.AddToRole(user.Id, "Editar");
            }
            if (!userManeger.IsInRole(user.Id, "Detalhes"))
            {
                userManeger.AddToRole(user.Id, "Detalhes");
            }
            if (!userManeger.IsInRole(user.Id, "Delete"))
            {
                userManeger.AddToRole(user.Id, "Delete");
            }
            
        }

        private void CreateSuperUser(ApplicationDbContext db)
        {
            var userManeger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManeger.FindByName("csergio@silva.com");
            if (user == null )
            {
                user = new ApplicationUser()
                {
                    UserName ="Sergio Silva",
                    Email = "csergio@silva.com"
                };

                userManeger.Create(user, "gms120605");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
         {
             var roleManeger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db)); 
             if(!roleManeger.RoleExists("Index")){

                 roleManeger.Create(new IdentityRole("Index"));         
        }
         if(!roleManeger.RoleExists("Cadastrar")){

                 roleManeger.Create(new IdentityRole("Cadastrar"));         
        }
         if(!roleManeger.RoleExists("Editar")){

                 roleManeger.Create(new IdentityRole("Editar"));         
        }
         if(!roleManeger.RoleExists("Detallhes")){

                 roleManeger.Create(new IdentityRole("Detalhes"));         
        }
         if(!roleManeger.RoleExists("Delete")){

                 roleManeger.Create(new IdentityRole("Delete"));         
        }
         }
    }
}
