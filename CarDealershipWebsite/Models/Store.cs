using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "characters must be 255 or less")]
        [RegularExpression("^[0-9]{1,4}[a-zA-Z\\s]*$", ErrorMessage = "Please enter valid address")]
        public string Address { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = "characters must be 20 or less")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")]

        public string City { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "characters must be 15 or less")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public ICollection<CarsStock> CarsStocks { get; set; } = new List<CarsStock>();

        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
    }
}