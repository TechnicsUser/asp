using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {

        public enum NotificationType {
            Registration,
            Email,
            Feedback
            }

        public class Notification {
        public int NotificationId { get; set; }
        public string Title { get; set; }

        [Display(Name = "About")]
        public NotificationType NotificationType { get; set; }
        public string Controller { get; set; }

        [Display(Name = "Message")]
        public string Action { get; set; }
        public string UserId { get; set; }
        public bool IsDismissed { get; set; }

        [Display(Name = "Received on")]
        public DateTime? CreatedOn { get; set; }

        public DateTime? DismissedOn { get; set; }

    }

}
   