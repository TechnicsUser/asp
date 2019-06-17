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

        [Required]
        public string Title { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Message To")]
        public string MessageTo { get; set; }
        public string MessageFrom { get; set; }
        public string UserId { get; set; }
        public bool IsDismissed { get; set; }

    }
}