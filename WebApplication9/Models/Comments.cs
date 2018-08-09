using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public string CommentId { get; set; }
        public CommentType Type { get; set; }

        public string UserId { get; set; }
        public string CreatedOn { get; set; }
        public string RemovedOn { get; set; }

        public string CommentOn { get; set; }

        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public int CommentViews { get; set; }

        public bool Removed { get; set; }
        public int Reports { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }


        }
    }