using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class CarsStock
    {
        [Key]
        public int StockID { get; set; }
        [Display(Name = "Car Model Number")]
        public int CarsModelId { get; set; }
        [ForeignKey("CarsModelId")]
        [Display(Name = "Car Model Number")]
        public CarsModel Model { get; set; }
        [Required]
        [Range(1950, 2100, ErrorMessage = "Please enter a valid year")]

        public int Year { get; set; }
        [Required]
        [Range(0, 999999, ErrorMessage = "Please enter a 6-digit number")]

        public int Mileage { get; set; }
        [Required]

        public bool Sold { get; set; }
        [Required]
        [Range(0, 999999, ErrorMessage = "Please enter a 6-digit number")]

        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Store")]

        public int StoreId { get; set; }
        [ForeignKey("StoreId")]

        public Store Store { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Please enter a valid license plate number. (less than 6 or less characters)")]
        [Display(Name = "License Plate")]

        public string LicensePlate { get; set; } = null!;
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}