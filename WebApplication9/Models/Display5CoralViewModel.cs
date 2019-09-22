using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApplication9.Models.Coral;


namespace WebApplication9.Models
{
    public class Display5CoralViewModel
    {
       
        public List<Coral> coralList { get; set; }
        public string MainHeading { get; set; }
        public string SubHeading { get; set; }
        public string LinkTo { get; set; }

        public Display5CoralViewModel(List<Coral> cl) {
            this.coralList = cl;
            MainHeading = "";
            SubHeading = "";
            }
        public Display5CoralViewModel(List<Coral> cl, string mh) {
            this.coralList = cl;
            MainHeading = mh;
            SubHeading = "";

            }
        public Display5CoralViewModel(List<Coral> cl, string mh, string sub) {
            this.coralList = cl;
            MainHeading = mh;
            SubHeading = sub;
            }
        public Display5CoralViewModel(List<Coral> cl, string mh, string sub, string link) {
            this.coralList = cl;
            MainHeading = mh;
            SubHeading = sub;
            LinkTo = link;
            }












        }
    }