using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealershipWebsite.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "characters must be 30 or less")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(30, ErrorMessage = "characters must be 30 or less")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed.")]
        [Display(Name = "Last Name")]

        public string LastName { get; set; } = null!;
        [Required]
        [StringLength(15, ErrorMessage = "characters must be 15 or less")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; } = null!;
        [Required]
        [StringLength(255, ErrorMessage = "characters must be 255 or less")]
        [RegularExpression("^[0-9]{1,3}[a-zA-Z\\s]*$", ErrorMessage = "Please enter valid address")]
        public string Address { get; set; } = null!;
        [Required]
        [Display(Name = "Store Number")]
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        [Display(Name = "Store Number")]
        public Store Store { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = "characters must be 20 or less")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed.")]

        public string City { get; set; } = null!;
    }
}