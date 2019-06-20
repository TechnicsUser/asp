using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication9.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        
        public string CssTheme { get; set; }

        public byte[] UserPhoto { get; set; }

        public string IdUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LocationLat { get; set; }
        public string LocationLon { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? RegistrationDate { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //internal object fishPhoto;

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebApplication9.Models.Coral> Corals { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Models.Fish> Fish { get; set; }
        public System.Data.Entity.DbSet<WebApplication9.Models.fishPhoto> FishPhoto { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Models.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Models.Comments> Comments { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Models.Messages> Messages { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Models.MessagesCreateViewModel> MessagesCreateViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Models.Feedback> Feedbacks { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Models.UserViewViewModel> UserViewViewModels { get; set; }
    }
}