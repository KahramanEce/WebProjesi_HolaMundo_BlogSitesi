using BlogProject.ViewComponents.User;
using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.NetworkInformation;
using X.PagedList;


namespace BlogProject.Controllers
{
    [AllowAnonymous]

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        Context c = new Context();


        public IActionResult Index(int page = 1)
        {
            var values = bm.GetBlogListWithCategory();
            return View(values.ToPagedList(page, 9));
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);

        }
        public PartialViewResult BlogUserAbout(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return PartialView(values);
        }
        public IActionResult BlogListByUser()
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = bm.GetListWithCategoryByUserBm(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,               //Dropdown 
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid) //Egerki sonuclar gecerliyse;
            {
                p.Status = true;
                p.BlogCreateDate = DateTime.Now;
                p.AppUserID = userId;
                bm.TAdd(p);
                return RedirectToAction("BlogListByUser", "Blog");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByUser");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,               //Dropdown 
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            p.AppUserID = userId;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByUser");
        }
      
    }
}
