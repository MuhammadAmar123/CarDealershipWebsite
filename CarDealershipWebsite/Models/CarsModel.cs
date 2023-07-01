using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class CarsModel
    {
        [Key]
        public int ModelID { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public string Model { get; set; } = null!;

        public int Seats { get; set; }

        public string EngineSize { get; set; } = null!;
        public int TransmissionId { get; set; }
        [ForeignKey("TransmissionId")]
        public Transmission Transmission { get; set; } = null!;
        public int FuelId { get; set; }
        [ForeignKey("FuelId")]
        public Fuel FuelType { get; set; } = null!;

        public string Drivetrain { get; set; } = null!;
        public ICollection<CarsStock> CarsStocks { get; set; } = new List<CarsStock>();
    }
}