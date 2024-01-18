using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        HomePageManager hpm = new HomePageManager(new EFHomePageRepository());
        public IActionResult Index()
        {
            return View();
        }
    }
}
