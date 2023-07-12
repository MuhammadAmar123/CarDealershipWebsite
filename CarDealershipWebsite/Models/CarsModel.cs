using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarDealershipWebsite.Models
{
    public class CarsModel
    {
        [Key] // data annotation identifies that ModelID field is the primary key
        public int ModelID { get; set; } // creates the coloumn to store data
        [Display(Name = "Brand")]  // changes the display name to this

        public int BrandId { get; set; } // creates the coloumn to store data
        [ForeignKey("BrandId")] // defines foriegn key colomn

        public Brand Brand { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in 
        [StringLength(30, ErrorMessage = "Field must be less than 30 characters")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data

        public string Model { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in 
        [Range(0, 10, ErrorMessage = "Please enter a valid seat range. (Between 0-10)")] // limits the amount of data that can be entered

        public int Seats { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in 
        [RegularExpression(@"^[0-9]+cc$", ErrorMessage = "Field must include only numbers and cc after the numbers")] // defines a specific way of entering data
        [Display(Name = "Engine Size")] // changes the display name to this

        public string EngineSize { get; set; } = null!; // creates the coloumn to store data
        [Display(Name = "Transmission")] // changes the display name to this

        public int TransmissionId { get; set; } // creates the coloumn to store data
        [ForeignKey("TransmissionId")] // defines foriegn key colomn

        public Transmission Transmission { get; set; } = null!; // creates the coloumn to store data
        [Display(Name = "Fuel")]  // changes the display name to this

        public int FuelId { get; set; } // creates the coloumn to store data
        [ForeignKey("FuelId")] // defines foriegn key colomn
        [Display(Name = "Fuel")] // changes the display name to this

        public Fuel FuelType { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in 
        [RegularExpression("^(4WD|AWD|FWD|RWD)$", ErrorMessage = "Invalid drivetrain. Must be either 4WD, AWD, FWD or RWD")] // defines a specific way of entering data

        public string Drivetrain { get; set; } = null!; // creates the coloumn to store data
        public ICollection<CarsStock> CarsStocks { get; set; } = new List<CarsStock>(); //add relationship that one car model can have many car stocks
    }
}