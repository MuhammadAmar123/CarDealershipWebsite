using Humanizer;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace CarDealershipWebsite.Models
{
    public class Fuel
    {
        [Key] // data annotation identifies that FuelID field is the primary key
        public int FuelID { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(15, ErrorMessage = "Field must be less than 15 characters")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [Display(Name = "Fuel")] // changes the display name to this
        public string FuelName { get; set; } // creates the coloumn to store data
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>(); // creates relationship that one fuel type can have many car models
    }
}