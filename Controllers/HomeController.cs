using Microsoft.AspNetCore.Mvc;

namespace MVC_Library_Management_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() // ana sayfa 
        {
            return View();
        }

        public IActionResult About() // hakkında sayfası
        {
            return View();
        }

        public IActionResult IsEmpty() // listelenecek eleman bulunamadı sayfası
        {
            return View();
        }
    }
}
