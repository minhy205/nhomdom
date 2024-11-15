using Koi.Repositories;
using Koi.Repositories.Entities;
using Koi.Repositories.Interfaces;
using Koi.Services.Interfaces;
using Koi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đọc chuỗi kết nối từ appsettings.json
// Đảm bảo rằng bạn đã có appsettings.json với phần connection string đúng
builder.Services.AddDbContext<KoifarmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Đảm bảo cấu hình chuỗi kết nối trong appsettings.json

// Thêm các dịch vụ khác vào container
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

// Đăng ký các repository
builder.Services.AddScoped<ICaKoiRepository, CaKoiRepository>();
builder.Services.AddScoped<IDanhGiaRepository, DanhGiaRepository>();
builder.Services.AddScoped<IGioHangCuaToiRepository, GioHangCuaToiRepository>();
builder.Services.AddScoped<IKyGuiRepository, KyGuiRepository>();
builder.Services.AddScoped<ILichSuMuaHangRepository, LichSuMuaHangRepository>();
builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();
builder.Services.AddScoped<IRepository<SanPham>, Repository<SanPham>>(); // Đăng ký repository cho SanPham
builder.Services.AddScoped<IUsersRepository, UserRepository>();

// Đăng ký các service
builder.Services.AddScoped<ICaKoiService, CaKoiService>();
builder.Services.AddScoped<IDanhGiaService, DanhGiaService>();
builder.Services.AddScoped<IGioHangCuaToiService, GioHangCuaToiService>();
builder.Services.AddScoped<IKyGuiService, KyGuiService>();
builder.Services.AddScoped<ILichSuMuaHangService, LichSuMuaHangService>();
builder.Services.AddScoped<INguoiDungService, NguoiDungService>();
builder.Services.AddScoped<ISanPhamServices, SanPhamServices>();
builder.Services.AddScoped<IUserServices, UserServices>();

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

// Đảm bảo đăng ký các endpoint
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
