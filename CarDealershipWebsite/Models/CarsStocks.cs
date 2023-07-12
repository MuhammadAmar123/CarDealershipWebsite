using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class CarsStock
    {
        [Key] // data annotation identifies that ModelID field is the primary key
        public int StockID { get; set; } // creates the coloumn to store data
        [Display(Name = "Car Model Number")] // changes the display name to this

        public int CarsModelId { get; set; } // creates the coloumn to store data
        [ForeignKey("CarsModelId")] // defines foriegn key colomn
        [Display(Name = "Car Model Number")] // changes the display name to this

        public CarsModel Model { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in 
        [Range(1950, 2100, ErrorMessage = "Please enter a valid year")]

        public int Year { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in 
        [Range(0, 999999, ErrorMessage = "Please enter a 6-digit number")] // limits the amount of data that can be entered

        public int Mileage { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in 

        public bool Sold { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in 
        [Range(0, 999999, ErrorMessage = "Please enter a 6-digit number")] // limits the amount of data that can be entered
        [DataType(DataType.Currency)] // changes the datatype
        public decimal Price { get; set; } // creates the coloumn to store data 
        [Required] // requires user to fill in 
        [Display(Name = "Store")] // changes the display name to this

        public int StoreId { get; set; } // creates the coloumn to store data
        [ForeignKey("StoreId")] // defines foriegn key colomn

        public Store Store { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in 
        [StringLength(6, ErrorMessage = "Please enter a valid license plate number. (less than 6 or less characters)")] // limits the amount of data that can be entered
        [Display(Name = "License Plate")] // changes the display name to this

        public string LicensePlate { get; set; } = null!; // creates the coloumn to store data
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    }
}