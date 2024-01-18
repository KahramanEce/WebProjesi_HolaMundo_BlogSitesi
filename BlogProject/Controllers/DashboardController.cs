using BusinessLayer.Concrate;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var usermodel = c.Users.SingleOrDefault(x => x.UserName == username);
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.AppUserID == userId).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }

    }
}
