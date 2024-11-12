using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Koi.WebApplication.Controllers
{
    public class giohang : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult giohangcuatoi()
        {
            return View();
        }

        public IActionResult lichsumuahang()
        {
            return View();
        }
        public IActionResult lichsukygui()
        {
            return View();
        }
        public IActionResult kyguicuatoi()
        {
            return View();
        }
    }
}

