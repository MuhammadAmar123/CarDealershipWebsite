using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class SaleItem
    {
        [Key]
        public int SaleItemID { get; set; }
        public int SaleId { get; set; }
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }
        public int CarsStockId { get; set; }
        [ForeignKey("CarsStockId")]
        public CarsStock Stock { get; set; }
    }
}