using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Brand
    {
        [Key] // data annotation identifies that BrandID field is the primary key
        public int BrandID { get; set; } // creating a field in my database named BrandID
        [Required] // requires user to fill in 
        [StringLength(15, ErrorMessage = "Field must be less than 15 characters")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")]
        [Display(Name = "Brand")]
        public string BrandName { get; set; } = null!;
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>();
    }
}
