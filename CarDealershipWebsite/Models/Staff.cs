using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        public string EmailAddress { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}