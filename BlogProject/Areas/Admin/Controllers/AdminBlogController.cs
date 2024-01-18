using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {    
        BlogManager blogManager= new BlogManager(new EFBlogRepository());
        public IActionResult Index(int page = 1)
        {
            var values = blogManager.GetBlogListWithCategory().ToPagedList(page, 7); 
            return View(values);
        }
        public IActionResult AdminBlogDelete(int id)
        {
            var value = blogManager.TGetById(id);
            blogManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
