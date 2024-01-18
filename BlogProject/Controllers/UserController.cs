using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Comment = EntityLayer.Concrete.Comment;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace BlogProject.Controllers
{
    public class UserController : Controller
    {
        UserManager wm = new UserManager(new EFUserRepository());
        UserManager userManager = new UserManager(new EFUserRepository());
        CommentManager cm = new CommentManager(new EFCommentRepository());
        Context c = new Context();


        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {

            return View();
        }
       
        [AllowAnonymous]
        public PartialViewResult UserNavbarPartial()
        {
            return PartialView(_userManager.Users.FirstOrDefault());
        }
        [AllowAnonymous]
        public PartialViewResult UserFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> UserEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.UserImage;
            model.username = values.UserName;
            model.userabout = values.UserAbout;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.UserImage = model.imageurl;
            values.Email = model.mail;
            values.UserAbout = model.userabout;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");

        }
        [HttpGet]
        public IActionResult UserAddCategory()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult UserAddCategory(Users p)
        //{
        //    var username = User.Identity.Name;
        //    var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        //    var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
        //    UserValidator bv = new UserValidator();
        //    ValidationResult result = bv.Validate(p);
        //    if (result.IsValid) //Egerki sonuclar gecerliyse;
        //    {
        //        //p.Status = true;
        //        wm.TAdd(p);
        //        return RedirectToAction("Index", "Dashboard");

        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();

        //}

        [HttpGet]
        public PartialViewResult NewComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> NewComment(Comment p)
        {
            p.CommentData = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            p.BlogID = 2;
            cm.CommentAdd(p);
            return PartialView();
        }

        public IActionResult DeleteUser(int id)
        {
            var users = userManager.TGetById(id);
            userManager.TDelete(users);
            return RedirectToAction("Index");
        }

      

    }
}
