using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {

    public enum MessageType {
        Registration,
        Email,
        Purchase,
        Sale,
        Accounts
        }


    public class Messages {
        [Key]
        public int MessageId { get; set; }
        public string Title { get; set; }
        public MessageType MessageType { get; set; }

        public int[] PreviousMessages { get; set; }

        public string MessageTo { get; set; }
        public string MessageFrom { get; set; }
        public string UserId { get; set; }
        public bool IsDismissed { get; set; }


        }
    }