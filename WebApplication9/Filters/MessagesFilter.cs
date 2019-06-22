

using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Filters {
    public class MessagesFilter : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            if(!filterContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = filterContext.HttpContext.User.Identity.Name;

            var context = new SiteDataContext();
            var messages = context.Messages
                 .Where(n => n.MessageTo == userId)
                 .Where(x => x.RecieverDeleted == false)
                .Where(n => n.Title != null)
               .Where(n => n.IsDismissed == false)
                .GroupBy(n => n.MessageTo)
                .Select(g => new MessagesViewModel {
                    Count = g.Count(),
                    MessageType = g.Key.ToString(),
                    BadgeClass =  "info"
                    });

            filterContext.Controller.ViewBag.Messages = messages;
            }
        }
    }