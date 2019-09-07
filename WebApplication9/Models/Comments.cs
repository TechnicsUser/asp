using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models {
    public class Comments {
        public enum CommentType {
            Coral,
            User,
            Store,
            Site,
            Accounts
            }

        [Key]
        public int CommentId { get; set; }

        public CommentType Type { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        public string UploadedBy { get; set; }
        public byte[] UserPhoto { get; set; }

        [Display(Name = "Created On")]
        public string CreatedOn { get; set; }
        public string RemovedOn { get; set; }
        [Display(Name = "Add")]
        public string CommentOn { get; set; }

        public string CommentTitle { get; set; }
        [Display(Name = "Text")]

        public string CommentText { get; set; }
        [Display(Name = "Views")]


        public int CommentViews { get; set; }

        public bool Removed { get; set; }
        public int Reports { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }


        }
    }