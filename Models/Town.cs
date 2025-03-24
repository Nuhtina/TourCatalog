using System.ComponentModel.DataAnnotations;

namespace TourCatalog.Models
{
    public class Town
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Город")]
        public string? Name { get; set; }
    }
}
