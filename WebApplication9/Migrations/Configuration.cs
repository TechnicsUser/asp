namespace WebApplication9.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication9.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication9.Models.SiteDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication9.Models.SiteDataContext context)
        {
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //// Create Admin Role
            //string roleName = "Admins";
            //IdentityResult roleResult;

            //// Check to see if Role Exists, if not create it
            //if(!RoleManager.RoleExists(roleName)) {
            //    roleResult = RoleManager.Create(new IdentityRole(roleName));
            //    }
            //if(!context.Roles.Any(r => r.Name == "AppAdmin")) {
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //    }

            //if(!context.Users.Any(u => u.UserName == "founder")) {
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "founder" };

            //    manager.Create(user, "ChangeItAsap!");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //    }
            }
    }
}
