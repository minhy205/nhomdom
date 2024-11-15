using Microsoft.AspNetCore.Mvc;
using Koi.Repositories.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Koi.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly KoifarmContext _context;

        public HomeController(KoifarmContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult khuyenmai()
        {
            return View();
        }

        public IActionResult gioithieusankigui()
        {
            return View();
        }

        public IActionResult gioithieutrang()
        {
            return View();
        }

        public IActionResult huongdandangkidangnhap()
        {
            return View();
        }

        public IActionResult thongtinkygui()
        {
            return View();
        }

        public IActionResult tintuctrang()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (user.Password != confirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Mật khẩu không khớp.");
                    return View(user);
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Đăng ký thành công!";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.Role);

                    TempData["Message"] = "Đăng nhập thành công!";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Sai tài khoản hoặc mật khẩu.");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Bạn đã đăng xuất thành công!";
            return RedirectToAction("Index");
        }
    }
}
