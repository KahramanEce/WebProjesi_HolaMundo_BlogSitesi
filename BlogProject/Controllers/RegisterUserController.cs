using BusinessLayer.Concrate;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {   //Kayıt Ol sayfası kodları
        private readonly UserManager<AppUser> _userManager;
        UserManager um = new UserManager(new EFUserRepository());
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {
            if (ModelState.IsValid) //Eğer yukaridaki islemler sağlandıysa 
            {
                AppUser user = new AppUser()
                {
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname,
                    UserAbout = p.UserAbout,
                    UserImage = "",
                    

                };
                var result = await _userManager.CreateAsync(user, p.Password);
                var roles = await _userManager.AddToRoleAsync(user, "User");

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
     
    }
}
