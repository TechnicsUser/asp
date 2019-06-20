using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class UserViewViewModel
    {
        [Key]
        public int FeedbackId { get; set; }

        public AspNetUser User { get; set; }
        public List<Feedback>  Feedback { get; set; }
        public int CoralAdds { get; set; }
        public int FishAdds { get; set; }
    }
}