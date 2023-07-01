using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarDealershipWebsite.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CarDealershipWebsiteContextConnection") ?? throw new InvalidOperationException("Connection string 'CarDealershipWebsiteContextConnection' not found.");

builder.Services.AddDbContext<CarDealershipWebsiteContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CarDealershipWebsiteUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CarDealershipWebsiteContext>();

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
app.Run();
