using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string City { get; set; } = null!;
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}