using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication9.Models
{
    public class MessagesCreateViewModel
    {
        [Key]
        public int MessageId { get; set; }
        public List<AspNetUser> Users { get; set; }


        public string Title { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }


        public string MessageTo { get; set; }
        public string MessageFrom { get; set; }
        public string UserId { get; set; }
        public bool IsDismissed { get; set; }

    }
}