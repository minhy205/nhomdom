using Koi.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext with the DI container
builder.Services.AddDbContext<CaKoiStoreContext>(options =>
    options.UseSqlServer("Data Source=localhost;Initial Catalog=CaKoi_Store;Persist Security Info=True;User ID=sa;Password=123456aA@$;MultipleActiveResultSets=True;TrustServerCertificate=True")); // Replace with your actual connection string

builder.Services.AddSession();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

