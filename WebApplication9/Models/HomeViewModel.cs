using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class HomeViewModel
    {
        public List<Coral> coralList { get; set; }

        public HomeViewModel(List<Coral> cl)
        {
            this.coralList = cl;
        }
    }
}