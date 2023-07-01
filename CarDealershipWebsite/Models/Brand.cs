using System.ComponentModel.DataAnnotations;

namespace CarDealershipWebsite.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; } = null!;
        public ICollection<CarsModel> CarsModels { get; set; } = new List<CarsModel>();
    }
}
