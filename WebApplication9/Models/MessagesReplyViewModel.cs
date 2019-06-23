using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication9.Models
{
    public class MessagesReplyViewModel
    {
        [Key]
        public int MessageId { get; set; }
 
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subject { get; set; }
      
        [Display(Name = "Message")]
        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Message To")]
        public string MessageTo { get; set; }
        [Display(Name = "From")]
        public string MessageFrom { get; set; }

        public string MessageFromUserId { get; set; }
        public bool IsDismissed { get; set; }

        public bool IsReply { get; set; }
        public string PreviousMessage { get; set; }
    }
}