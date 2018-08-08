namespace WebApplication9.Migrations
{
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Notifications.AddOrUpdate(notification => notification.Title,
       new Notification {
           Title = "John Smith was added to the system.",
           NotificationType = NotificationType.Registration
           },
       new Notification {
           Title = "Susan Peters was added to the system.",
           NotificationType = NotificationType.Registration
           },
       new Notification {
           Title = "Just an FYI on Thursday’s meeting",
           NotificationType = NotificationType.Email
           });
            }
    }
}
