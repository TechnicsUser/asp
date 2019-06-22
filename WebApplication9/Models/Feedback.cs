using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public enum FeedbackType
    {
        Positive,
        Negative,
        Nutral
    }

    public class Feedback
    {


        [Key]
        public int FeedbackId { get; set; }
        public FeedbackType FeedbackType { get; set; }


        [Display(Name = "Feedback")]
        public string Content { get; set; }

        public bool? IsReply { get; set; }
        public int?[] PreviousFeedbacks { get; set; }

        public AspNetUser FeedbackFor { get; set; }
        [Display(Name = "For")]
        public string FeedbackForUserId { get; set; }


        public AspNetUser FeedbackFrom { get; set; }
        [Display(Name = "From")]
        public string FeedbackFromUserId { get; set; }

        [Display(Name = "Seen")]
        public bool IsDismissed { get; set; }

        public bool? SenderDeleted { get; set; }
        public bool? RecieverDeleted { get; set; }

        public bool? IsReported { get; set; }
        public string ReportedBy { get; set; }

        [Display(Name = "Received on")]
        public DateTime? CreatedOn { get; set; }
        //public string createdString {
        //    get {
        //        string time = this.CreatedOn.ToString().Substring(0, 6);
        //        return time;
        //    }
        //}

        public DateTime? DismissedOn { get; set; }
        public DateTime? SenderDeletedOn { get; set; }
        public DateTime? RecieverDeletedOn { get; set; }
        public int? Reports { get; internal set; }
    }
}
