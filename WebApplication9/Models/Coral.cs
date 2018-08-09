using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models {
    public class Coral {


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


        [Key]
        public int CoralId { get; set; }
        public CoralType Type { get; set; }
        public LightRequirement Light { get; set; }
        public FlowRequirement Flow { get; set; }
        public FoodRequirement Food { get; set; }

        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Details { get; set; }

        public int[] PhotoId { get; set; }



        public string UploadedBy { get; set; }

        public string CommentId { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }

        public bool IsDismissed { get; set; }
        public bool FragAvailable { get; set; }
        public string FragAvailableFrom { get; set; }


        }
    }
    