using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public DateTime SaleDate { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}