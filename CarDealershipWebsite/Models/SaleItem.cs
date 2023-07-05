using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class SaleItem
    {
        [Key]
        public int SaleItemID { get; set; }
        [Display(Name = "Sale Number")]

        public int SaleId { get; set; }
        [ForeignKey("SaleId")]
        [Display(Name = "Sale Number")]
        public Sale Sale { get; set; }
        [Display(Name = "Car Stock Number")]

        public int CarsStockId { get; set; }
        [ForeignKey("CarsStockId")]
        [Display(Name = "Car Stock Number")]

        public CarsStock Stock { get; set; }

    }
}