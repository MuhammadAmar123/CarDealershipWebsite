using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Transmission
    {
        [Key] // data annotation identifies that TransmissionID field is the primary key
        public int TransmissionID { get; set; } // creates the coloumn to store data
        [Required]  // requires user to fill in
        [StringLength(15, ErrorMessage = "Field must be less than 15 characters")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [Display(Name = "Transmission")] // changes the display name to this
        public string TransmissionName { get; set; } = null!; // creates the coloumn to store data
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>(); //creates relationship that one transmission can have many car models
    }
}