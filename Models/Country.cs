using System.ComponentModel.DataAnnotations;

namespace TourCatalog.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; } 



        [Required]
        [StringLength(50)]
        [Display(Name = "Страна")]
        public string? Name { get; set; }
    }
}
