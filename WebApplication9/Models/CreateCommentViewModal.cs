using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication9.Models
{
    public class CreateCommentViewModal {
        public CreateCommentViewModal(Coral c, AspNetUser user)

        {
            CommentOn = c.CoralId.ToString();
            UserId = user.IdUserName;
        }

        public CreateCommentViewModal()
        {
            throw new NotImplementedException();
        }

        public CreateCommentViewModal(Coral modelCoral, string identityName)
        {
            CommentOn = modelCoral.CoralId.ToString();
            UserId = identityName;
        }

        //public int Count { get; set; }
        // public string BadgeClass { get; set; }
        public enum CommentType
        {
            Fish,
            Coral,
            User,
            Equipment,
            Site,
            
        }

        [Key]
        public int CommentId { get; set; }
        public CommentType Type { get; set; }

        public byte[] UserPhoto { get; set; }

        public string UserId { get; set; }
        public string CreatedOn { get; set; }
 
        public string CommentOn { get; set; }

        [Display(Name = "Say something...")]
         public string CommentText { get; set; }
     


    }
}