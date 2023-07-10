using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CarDealershipWebsite.Areas.Identity.Data;
public class Program
{

    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("CarDealershipWebsiteContextConnection") ?? throw new InvalidOperationException("Connection string 'CarDealershipWebsiteContextConnection' not found.");

        builder.Services.AddDbContext<CarDealershipWebsiteContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<CarDealershipWebsiteUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CarDealershipWebsiteContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CarDealershipWebsiteUser>>();
            var users = await userManager.Users.ToListAsync();

            var excludedEmails = new List<string> { "admin@admin.com" };

            foreach (var user in users)
            {
                if (!excludedEmails.Contains(user.Email))
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }

        app.Run();

    }
}



