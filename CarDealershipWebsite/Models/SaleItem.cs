using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class SaleItem
    {
        [Key] // data annotation identifies that SaleItemID field is the primary key
        public int SaleItemID { get; set; } // creates the coloumn to store data
        [Display(Name = "Sale Number")] // changes the display name to this

        public int SaleId { get; set; } // creates the coloumn to store data
        [ForeignKey("SaleId")] //sets this value to foreign key
        [Display(Name = "Sale Number")] // changes the display name to this
        public Sale Sale { get; set; } // creates the coloumn to store data
        [Display(Name = "Car Stock Number")] // changes the display name to this

        public int CarsStockId { get; set; } // creates the coloumn to store data
        [ForeignKey("CarsStockId")] //sets this value to foreign key
        [Display(Name = "Car Stock Number")] // changes the display name to this

        public CarsStock Stock { get; set; } // creates the coloumn to store data

    }
}