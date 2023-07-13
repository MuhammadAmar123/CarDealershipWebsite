using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class Sale
    {
        [Key] // data annotation identifies that SaleID field is the primary key
        public int SaleID { get; set; } // creates the coloumn to store data
        [Display(Name = "Customer Number")] // changes the display name to this

        public int CustomerId { get; set; } // creates the coloumn to store data
        [ForeignKey("CustomerId")] // sets this to foreign key
        [Display(Name = "Customer Number")] // changes the display name to this
        public Customer Customer { get; set; } // creates the coloumn to store data
        [Required] // requires user to fill in
        [DataType(DataType.Date)] // changes datatype to this
        [Display(Name = "Sale Date")] // changes the display name to this

        public DateTime SaleDate { get; set; } // creates the coloumn to store data
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}