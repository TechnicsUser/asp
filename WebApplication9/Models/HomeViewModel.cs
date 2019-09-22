using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class HomeViewModel
    {
        public List<Coral> coralList { get; set; }
        public List<Coral> feeeCoralList { get; set; }
        public List<Coral> display5CoralList { get; set; }

        //public HomeViewModel(List<Coral> cl) {
        //    this.coralList = cl;
        //    }
        public HomeViewModel(List<Coral> cl, List<Coral> feeeCoralList, List<Coral> display5CoralList) {
            this.coralList = cl;
            this.feeeCoralList = feeeCoralList;
            this.display5CoralList = display5CoralList;
            }
        }
}