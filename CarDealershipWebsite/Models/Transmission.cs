using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Transmission
    {
        [Key]
        public int TransmissionID { get; set; }
        public string TransmissionName { get; set; } = null!;
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>();
    }
}