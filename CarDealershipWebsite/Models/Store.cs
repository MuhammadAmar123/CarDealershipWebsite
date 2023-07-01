using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<CarsStock> CarsStocks { get; set; } = new List<CarsStock>();

        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
    }
}