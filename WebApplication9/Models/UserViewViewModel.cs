using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class UserView
    {
        [Key]
        public int FeedbackId { get; set; }

        public AspNetUser User { get; set; }
        public List<Feedback>  Feedback { get; set; }
        public int CoralAdds { get; set; }
        public string CoralAddsId { get; set; }
        public int FishAdds { get; set; }
        public string FishAddsId { get; set; }
        public DateTime? lastOnline { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public int positiveFeedbacks { get; set; }
        public int negativeFeedbacks { get; set; }
        public int nutralFeedbacks { get; set; }
    }
}