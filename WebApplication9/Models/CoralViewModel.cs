using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApplication9.Models.Coral;


namespace WebApplication9.Models
{
    public class CoralViewModel
    {
        public List<Coral> coralList { get; set; }

        public CoralViewModel(List<Coral> cl)
        {
            this.coralList = cl;
        }


    }
}