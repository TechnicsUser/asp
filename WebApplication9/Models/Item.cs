using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Item
    {
        [Required]
        public string Name { get; set; }
        public string ScientificName { get; set; }
        [Required]

        public string Details { get; set; }

        [Display(Name = "Contact")]
        public string UploadedBy { get; set; }
        public string UploadedOn { get; set; }
        public string CommentId { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public int Views { get; set; }

        public bool SoldOut { get; set; }
    }
}