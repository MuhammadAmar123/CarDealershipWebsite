using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class Staff
    {
        [Key] // data annotation identifies that StaffID field is the primary key
        public int StaffID { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(30, ErrorMessage = "characters must be 30 or less")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [Display(Name = "First Name")] // changes the display name to this
        public string FirstName { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(30, ErrorMessage = "characters must be 30 or less")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [Display(Name = "Last Name")] // changes the display name to this

        public string LastName { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(15, ErrorMessage = "characters must be 15 or less")] // limits the amount of data that can be entered
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Please enter a valid phone number")] // defines a specific way of entering data
        [Display(Name = "Phone Number")] // changes the display name to this

        public string PhoneNumber { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(255, ErrorMessage = "characters must be 255 or less")] // limits the amount of data that can be entered
        [RegularExpression("^[0-9]{1,3}[a-zA-Z\\s]*$", ErrorMessage = "Please enter valid address")] // defines a specific way of entering data

        public string Address { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in
        [Display(Name = "Store")] // changes the display name to this

        public int StoreId { get; set; } // creates the coloumn to store data
        [ForeignKey("StoreId")] // defines foriegn key colomn
        [Display(Name = "Store")] // changes the display name to this

        public Store Store { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in
        [DataType(DataType.EmailAddress)] // changes datatype to this
        [Display(Name = "Email Address")] // changes the display name to this

        public string EmailAddress { get; set; } = null!; // creates the coloumn to store data
        [Required] // requires user to fill in
        [StringLength(20, ErrorMessage = "characters must be 20 or less")] // limits the amount of data that can be entered
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data

        public string City { get; set; } = null!; // creates the coloumn to store data
    }
}