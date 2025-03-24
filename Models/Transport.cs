using System.ComponentModel.DataAnnotations;

namespace TourCatalog.Models
{
    public class Transport
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Название транспорта")]
        public string? Name { get; set; }
    }
}
