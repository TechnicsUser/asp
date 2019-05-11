using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
  

    public class MessagesCreateViewModel
    {
        public Messages message;
        public List<AspNetUser> userList;
        public string UserId = "";
        public string id = "";
        //public string MessageTo { get; set; }
        //public string Title { get; set; }
        //public string Subject { get; set; }
        //public string Content { get; set; }

        public MessagesCreateViewModel()
        {

        }
        public MessagesCreateViewModel(Messages msg, List<AspNetUser> userList)
        {
            this.message = msg;
            this.userList = userList;

        }
        public MessagesCreateViewModel(Messages msg, string UserId, string id )
        {
            this.message = msg;
            this.UserId = UserId;
            this.id = id;
        }


    }
}