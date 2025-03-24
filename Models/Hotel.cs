using System.ComponentModel.DataAnnotations;

namespace TourCatalog.Models
{
    public class Hotel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Название отеля")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Количество звезд")]
        public int stars { get; set; }
    }
}
