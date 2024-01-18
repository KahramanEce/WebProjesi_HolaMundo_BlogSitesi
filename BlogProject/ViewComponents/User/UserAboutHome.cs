using BusinessLayer.Concrate;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.User
{
    public class UserAboutHome : ViewComponent
    {
        UserManager usermanager = new UserManager(new EFUserRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {

            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            var values = usermanager.GetUserById(userId);
            return View(values);
        }
    }
}
