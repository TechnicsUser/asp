using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class DisplayCommentViewModal {
        public DisplayCommentViewModal(Comments c, AspNetUser user)

        {
            CommentOn = c.CommentOn;
            CreatedOn = c.CreatedOn;

                IdUserName = c.UserId;
            CommentText = c.CommentText;

            UserPhoto = c.UserPhoto;
        }

        public DisplayCommentViewModal()
        {
            throw new NotImplementedException();

        }

 

        [Key]
        public int CommentId { get; set; }

        public byte[] UserPhoto { get; set; }

        public string IdUserName { get; set; }

        public string CreatedOn { get; set; }
        public string CommentOn { get; set; }
        public string CommentBy { get; set; }

        public string CommentText { get; set; }
     


    }
}