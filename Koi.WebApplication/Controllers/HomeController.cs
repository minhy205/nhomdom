using Microsoft.AspNetCore.Mvc;
using Koi.Repositories.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Koi.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly KoifarmContext _context;

        public HomeController(KoifarmContext context)
        {
            _context = context;
        }

        public IActionResult index()
        {
            return View();
        }
        //public IActionResult gioithieu()
        //{
        //    return View();
        //}
        //public IActionResult cakoi()
        //{
        //    return View();
        //}
        //public IActionResult thongtinkygui()
        //{
        //    return View();
        //}
        //public IActionResult tintuctrang()
        //{
        //    return View();
        //}
        //public IActionResult giohang()
        //{
        //    return View();
        //}
        public IActionResult login()
        {
            return View();
        }
        //public IActionResult gioithieusankigui()
        //{
        //    return View();
        //}
        //public IActionResult huongdandangkidangnhap()
        //{
        //    return View();
        //}
        public IActionResult register ()
        {
            return View();
        }
        //public IActionResult danhgia()
        //{
        //    return View();
        //}
        //public IActionResult lichsumuahang()
        //{
        //    return View();
        //}
        //public IActionResult lichsukygui()
        //{
        //    return View();
        //}
        //public IActionResult kyguicuatoi()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Register(User user, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (user.Password != confirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Passwords do not match.");
                    return View(user);
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    // Store user information in session
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.Role);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View();
        }

        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
