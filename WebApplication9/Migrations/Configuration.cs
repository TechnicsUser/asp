namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication9.Models.SiteDataContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication9.Models.SiteDataContext context)
        {
            context.Corals.AddOrUpdate(x => x.CoralId,
        new Models.Coral() { CoralId = 1, Name = "Toadstool" },
        new Models.Coral() { CoralId = 2, Name = "Kenya Tree", },
        new Models.Coral() { CoralId = 3, Name = "Mushroom" },
        new Models.Coral() { CoralId = 4, Name = "Gsp" },
                new Models.Coral() { CoralId = 5, Name = "Psp" }


        );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
