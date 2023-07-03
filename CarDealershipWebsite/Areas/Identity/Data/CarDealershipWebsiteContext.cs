using CarDealershipWebsite.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealershipWebsite.Models;

namespace CarDealershipWebsite.Areas.Identity.Data;

public class CarDealershipWebsiteContext : IdentityDbContext<CarDealershipWebsiteUser>
{
    public CarDealershipWebsiteContext(DbContextOptions<CarDealershipWebsiteContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }


    public DbSet<Brand> Brands { get; set; }
    public DbSet<CarsModel> CarsModels { get; set; }
    public DbSet<CarsStock> CarsStocks { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Store> Stores { get; set; }

}
