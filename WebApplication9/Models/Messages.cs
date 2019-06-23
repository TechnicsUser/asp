using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{

    public enum MessageType
    {
        Registration,
        Email,
        Purchase,
        Sale,
        Accounts,
        Other
    }


    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public MessageType MessageType { get; set; }

        public string Title { get; set; }
        public string Subject { get; set; }
        [Display(Name = "Message")]
        public string Content { get; set; }

        public bool IsReply { get; set; }
        public string PreviousMessage { get; set; }

        public string MessageTo { get; set; }

        [Display(Name = "From")]
        public string MessageFrom { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Seen")]
        public bool IsDismissed { get; set; }

        public bool SenderDeleted { get; set; }
        public bool RecieverDeleted { get; set; }

        public bool IsReported { get; set; }

        [Display(Name = "Received on")]
        public DateTime? CreatedOn { get; set; }
        public DateTime? DismissedOn { get; set; }
        public DateTime? SenderDeletedOn { get; set; }
        public DateTime? RecieverDeletedOn { get; set; }


    }
}