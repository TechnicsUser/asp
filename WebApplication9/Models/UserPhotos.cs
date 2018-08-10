using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {
    public class UserPhotos {
        public enum PhotoOf {
            Coral,
            User,
            Tank,
            Equipment,
            Other
            }
        public enum Lighting {
            T5,
            T8,
            Led,
            Mh,
            T5LedCombo,
            Other
            }
        [Key]
        int PhotoId { get; set; }
        byte[] Photo { get; set; }

        public PhotoOf Type { get; set; }
        public Lighting LightingType { get; set; }
        public string UserId { get; set; }
        public string CreatedOn { get; set; }
        public string RemovedOn { get; set; }
        public string LastAccessed { get; set; }

        public string CameraType { get; set; }


        public int Views { get; set; }
        public string Format { get; set; }





        }
    }