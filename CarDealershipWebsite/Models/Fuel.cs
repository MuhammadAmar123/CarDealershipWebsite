using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Fuel
    {
        [Key]
        public int FuelID { get; set; }
        public string FuelName { get; set; }
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>();
    }
}