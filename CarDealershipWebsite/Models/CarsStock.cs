using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class CarsStock
    {
        [Key]
        public int StockID { get; set; }
        public int CarsModelId { get; set; }
        [ForeignKey("CarsModelId")]
        public CarsModel Model { get; set; }
        public int Year { get; set; }

        public int Mileage { get; set; }

        public bool Sold { get; set; }

        public decimal Price { get; set; }

        public int StoreId { get; set; }

        [ForeignKey("StorelId")]
        public Store Store { get; set; }

        public string LicensePlate { get; set; } = null!;
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}