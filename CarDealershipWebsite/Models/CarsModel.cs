using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class CarsModel
    {
        [Key]
        public int ModelID { get; set; }
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Field must be less than 30 characters")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")]

        public string Model { get; set; } = null!;
        [Required]
        [Range(0, 10, ErrorMessage = "Please enter a valid seat range. (Between 0-10)")]

        public int Seats { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+cc$", ErrorMessage = "Field must include only numbers and cc after the numbers")]
        [Display(Name = "Engine Size")]

        public string EngineSize { get; set; } = null!;
        [Display(Name = "Transmission")]

        public int TransmissionId { get; set; }
        [ForeignKey("TransmissionId")]

        public Transmission Transmission { get; set; } = null!;
        [Display(Name = "Fuel")]

        public int FuelId { get; set; }
        [ForeignKey("FuelId")]
        [Display(Name = "Fuel")]

        public Fuel FuelType { get; set; } = null!;
        [Required]
        [RegularExpression("^(4WD|AWD|FWD|RWD)$", ErrorMessage = "Invalid drivetrain. Must be either 4WD, AWD, FWD or RWD")]

        public string Drivetrain { get; set; } = null!;
        public ICollection<CarsStock> CarsStocks { get; set; } = new List<CarsStock>();
    }
}