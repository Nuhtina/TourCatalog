using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourCatalog.Models
{
    public class TripCatalog
    {
        [Key] 
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Название тура")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Стоимость")]
        public decimal Price { get; set; }

        public int CountryID { get; set; }
        [ForeignKey("ID")]
        [Display(Name = "Страна")]
        public Country? Country { get; set; }

        public int TownID { get; set; }
        [ForeignKey("ID")]
        [Display(Name = "Город")]
        public Town? Town { get; set; }

        public int TransportID { get; set; }
        [ForeignKey("ID")]
        [Display(Name = "Транспорт")]
        public Transport? Transport { get; set; }

        public int TypeID { get; set; }
        [ForeignKey("ID")]
        [Display(Name = "Тип тура")]
        public Type_tour? Type_tours { get; set; }

        public int HotelID { get; set; }
        [ForeignKey("ID")]
        [Display(Name = "Отель")]
        public Hotel? Hotel { get; set; }
    }
}
