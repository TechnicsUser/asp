using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {


    public class SiteDataContext : DbContext {
        public SiteDataContext() : base("DefaultConnection") { }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Messages> Messages { get; set; }
        public DbSet<AspNetUser> AspNetUser { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Coral> Corals { get; set; }
        public DbSet<CoralPhoto> CoralPhoto { get; set; }
        public DbSet<CoralConnection> CoralConnections { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<fishPhoto> FishPhoto { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }



        //public  DbSet<ApplicationIdentity> UserLogins { get; set; }
        // public object Roles { get; internal set; }
    }
}
