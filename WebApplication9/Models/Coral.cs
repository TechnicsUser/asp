using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {
    public class Coral : Item{

        public List<CoralPhoto> PhotoList { get; set; }

        public enum CoralType {
            Soft,
            LPS,
            SPS,
            Annemone,
            Other
            }
        public enum LightRequirement {
            Max,
            High,
            Modorate,
            Low,
            None
            }
        public enum FlowRequirement {
            Max,
            High,
            Modorate,
            Low,
            None
            }
        public enum FoodRequirement {
            Max,
            High,
            Modorate,
            Low,
            None
            }
        public enum GrowthSpeed {

            /// <summary>
            ///  change these
            /// </summary>
            Extreme,
            VeryFast,
            Fast,
            Modorate,
            Slow,
            VerySlow,
            Low,
            None
            }


        [Key]
        public int CoralId { get; set; }
        public CoralType Type { get; set; }
        public LightRequirement Light { get; set; }
        public FlowRequirement Flow { get; set; }
        public FoodRequirement Food { get; set; }
        public GrowthSpeed Growth { get; set; }
     
       
       
 


        public int[] PhotoId { get; set; }
        public byte[] Photo { get; set; }


        [Required]

        public string Price { get; set; }
        public string Size { get; set; }
        public string FragSize { get; set; }

   

        //public bool SoldOut { get; set; }
        public bool FragAvailable { get; set; }
        public string FragAvailableFrom { get; set; }


        }
    }
    