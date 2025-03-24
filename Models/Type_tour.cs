using System.ComponentModel.DataAnnotations;

namespace TourCatalog.Models
{
    public class Type_tour
    {
        [Key] 
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Тип тура")]
        public string? Name { get; set; }
    }
}
