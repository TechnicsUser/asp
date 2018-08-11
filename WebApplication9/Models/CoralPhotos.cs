using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {
    public class CoralPhotos {
       [Key ]

        public int CoralPhotoId { get; set; }
        public int CoralId { get; set; }
        public string UserId { get; set; }
        public string CreatedOn { get; set; }
        public string RemovedOn { get; set; }
        public bool Removed { get; set; }



        }
    }