using Microsoft.AspNetCore.Mvc;

namespace Web_IoT.Controllers
{
    public class HomeController : Controller
    {
        // Landing (Ana Sayfa)
        public IActionResult Index()
        {
            return View();
        }

        // Gizlilik Politikası (mevcut)
        public IActionResult Privacy()
        {
            return View();
        }

        // Sık Sorulan Sorular
        public IActionResult Faq()
        {
            return View();
        }

        // Hakkımızda
        public IActionResult About()
        {
            return View();
        }

        // Fiyatlandırma
        public IActionResult Pricing()
        {
            return View();
        }
    }
}
