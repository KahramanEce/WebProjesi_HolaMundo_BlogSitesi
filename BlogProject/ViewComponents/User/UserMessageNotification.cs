using BusinessLayer.Concrate;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class UserMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EFMessageRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            
            var values = mm.GetInBoxListByUser(userId);
            return View(values);
        }
    }
}
