using BusinessLayer.Concrate;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        UserManager userManager=new UserManager (new EFUserRepository ());
        public IActionResult Index(int page = 1)
        {

            Context c = new Context();
            var values = c.Users.ToList().ToPagedList(page, 7);
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            var users = userManager.TGetById(id);
            userManager.TDelete(users);
            return RedirectToAction("Index");
        }
    }
}
