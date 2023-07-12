using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Brand
    {
        [Key] // data annotation identifies that BrandID field is the primary key
        public int BrandID { get; set; } // creating a field in my database named BrandID
        [Required] // requires user to fill in 
        [StringLength(15, ErrorMessage = "Field must be less than 15 characters")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [Display(Name = "Brand")] // changes the display name to this
        public string BrandName { get; set; } = null!; // creates the coloumn to store data
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>(); // adds relationship that one brand can go to many car models
    }
}
