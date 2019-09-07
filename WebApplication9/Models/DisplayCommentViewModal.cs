using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class DisplayCommentViewModal {
        public DisplayCommentViewModal(Comments c, AspNetUser user) {
            CommentOn = c.CommentOn;
            CreatedOn = c.CreatedOn;
            CommentId = c.CommentId;
            IdUserName = c.UserId;
            CommentText = c.CommentText;
            CommentBy = c.UploadedBy;
            UserPhoto = c.UserPhoto;
            }
        public DisplayCommentViewModal(Comments c) {
            CommentOn = c.CommentOn;
            CreatedOn = c.CreatedOn;
            CommentId = c.CommentId;
            IdUserName = c.UserId;
            CommentText = c.CommentText;
            CommentBy = c.UploadedBy;
            UserPhoto = c.UserPhoto;
            }
        //public DisplayCommentViewModal(Comments c, Coral coral) {
        //    CommentOn = c.CommentOn;
        //    CreatedOn = c.CreatedOn;
        //    CommentId = c.CommentId;
        //    IdUserName = c.UserId;
        //    CommentText = c.CommentText;
        //    CommentBy = c.UploadedBy;
        //    UserPhoto = coral.Photo;
        //    }

        public DisplayCommentViewModal()
        {
            throw new NotImplementedException();

        }

 

        [Key]
        public int CommentId { get; set; }

        public byte[] UserPhoto { get; set; }

        public string IdUserName { get; set; }
        private string _createdOn;

        public string CreatedOn
        {
            get
            {

                DateTime date1 = DateTime.Parse(this._createdOn);
                DateTime date2 = DateTime.Today;
                int daysDiff = ((TimeSpan)(date2 - date1)).Days;
                if (daysDiff == 0)
                {
                    _createdOn = "Today";

                }
                else if (daysDiff == 1)
                {
                    _createdOn = "Yesterday";

                }
                else
                {
                    _createdOn = daysDiff +  "Days ago";
                }

                return _createdOn;

            }

            set =>this._createdOn = value;

            
        }
        public string CommentOn { get; set; }
        public string CommentBy { get; set; }

        public string CommentText { get; set; }
     


    }
}