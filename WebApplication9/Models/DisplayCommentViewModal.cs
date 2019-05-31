using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication9.Models
{
    public class DisplayCommentViewModal {
        public DisplayCommentViewModal(Comments c, AspNetUser user)

        {
            CommentOn = c.CommentOn;
            IdUserName = c.UserId;
            CommentText = c.CommentText;
            //UserPhoto = user.UserPhoto;
        }

        public DisplayCommentViewModal()
        {
            throw new NotImplementedException();

        }

 

        [Key]
        public int CommentId { get;}

        public byte[] UserPhoto { get;  }

        public string IdUserName { get; }
        public string CreatedOn { get;}
 
        public string CommentOn { get; }

         public string CommentText { get; }
     


    }
}