using Koi.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đọc chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("KoifarmDatabase");

// Đăng ký DbContext với chuỗi kết nối
builder.Services.AddDbContext<KoifarmContext>(options =>
    options.UseSqlServer(connectionString));

// Thêm các dịch vụ khác vào container
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// Cấu hình middleware
app.UseSession();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

