using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        [Display(Name = "Customer Number")]

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [Display(Name = "Customer Number")]
        public Customer Customer { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Sale Date")]

        public DateTime SaleDate { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}