using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Fuel
    {
        [Key]
        public int FuelID { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Field must be less than 15 characters")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")]
        [Display(Name = "Fuel")]
        public string FuelName { get; set; }
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>();
    }
}