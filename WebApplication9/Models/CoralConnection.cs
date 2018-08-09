using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {
    public class CoralConnection {


        [Key]
        public int ConnectionId { get; set; }
        public int CoralId { get; set; }
        public string UserId { get; set; }
        public string CreatedOn { get; set; }
        public string RemovedOn { get; set; }
        public bool Removed { get; set; }


        public string FragTo { get; set; }
        public string FragFrom { get; set; }
        public string ColonyTo { get; set; }
        public string ColonyFrom { get; set; }



        }
    }