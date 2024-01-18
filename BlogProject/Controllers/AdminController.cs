using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        //Admin paneli sol sayfalar kısmı
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
