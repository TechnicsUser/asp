using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using static WebApplication9.Models.ApplicationUser;
using static WebApplication9.Models.Coral;

namespace WebApplication9.Models {
    public class CoralDetailsViewModel {
        public AspNetUser user { get; set; }
        public List<CoralPhoto> rl { get; set; }
        public List<Comments> cl { get; set; }
        public Coral coral   { get; set; }
        public CoralDetailsViewModel(Coral coral, AspNetUser user, List<CoralPhoto> rl, List<Comments> cl)
        {
            this.cl = cl;
            this.coral = coral;
            this.user = user;
            this.rl = rl;
        }
 

    }
}