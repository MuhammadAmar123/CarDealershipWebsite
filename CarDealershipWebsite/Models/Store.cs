using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Store
    {
        [Key] // data annotation identifies that StoreID field is the primary key
        public int StoreID { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(255, ErrorMessage = "characters must be 255 or less")] // limits the amount of data that can be entered
        [RegularExpression("^[0-9]{1,4}[a-zA-Z\\s]*$", ErrorMessage = "Please enter valid address")] // defines a specific way of entering data
        public string Address { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(20, ErrorMessage = "characters must be 20 or less")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data

        public string City { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(15, ErrorMessage = "characters must be 15 or less")] // limits the amount of data that can be entered
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Please enter a valid phone number")] // defines a specific way of entering data
        [Display(Name = "Phone Number")] // changes the display name to this
        public string PhoneNumber { get; set; } // creates the coloumn to store data
        public ICollection<CarsStock> CarsStocks { get; set; } = new List<CarsStock>(); // creates relationship that one store can have many car stocks

        public ICollection<Staff> Staffs { get; set; } = new List<Staff>(); // creates relaionship that one store can have many staffs
    }
}