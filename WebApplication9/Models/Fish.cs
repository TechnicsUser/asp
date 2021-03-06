﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication9.Models {
    public class Fish : Item {

        public enum FishType {

            Angels_dwarf,
            Angels_large,
            Anthias,
            Blennies,
            Box_Fish,
            Butterfly,
            Cardinal,
            ClownFish,
            Damsel,
            Dartfish,
            Dottybacks,
            Dragonets,
            Eels,
            Filefish,
            Foxface,
            Gobies,
            Jawfish,
            Lion_Fish,
            Puffers,
            Seahorses,
            Tangs,
            Triggers,
            Wrasse,
            Other
            }
        public enum TankSizeRequirement {
            /// <summary>
            ///  change these
            /// </summary>
            Max,
            High,
            Modorate,
            Low,
            None
            }
        //public enum FlowRequirement {
        //    Max,
        //    High,
        //    Modorate,
        //    Low,
        //    None
        //    }
        //public enum FoodRequirement {
        //    Max,
        //    High,
        //    Modorate,
        //    Low,
        //    None
        //    }
        //public enum GrowthSpeed {

         
        //    Extreme,
        //    VeryFast,
        //    Fast,
        //    Modorate,
        //    Slow,
        //    VerySlow,
        //    Low,

        //    }


        [Key]
        public int FishId { get; set; }
        public FishType Type { get; set; }
        public TankSizeRequirement TankSize { get; set; }
        //public FlowRequirement Flow { get; set; }
        //public FoodRequirement Food { get; set; }
        //public GrowthSpeed Growth { get; set; }



        public int[] PhotoId { get; set; }
        public byte[] Photo { get; set; }



  
        public string Price { get; set; }
        public string Size { get; set; }
        public string FishSize { get; set; }

   
        public bool FishAvailable { get; set; }
        public string FishAvailableFrom { get; set; }


        }
    }