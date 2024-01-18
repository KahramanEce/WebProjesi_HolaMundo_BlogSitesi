using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Category = EntityLayer.Concrete.Category;

namespace CoreDemo.Areas.Admin.Controllers
{    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,4);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        { 
            CategoryValidator bv = new CategoryValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                cm.TAdd(p);  
                return RedirectToAction("Index", "Category");

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
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CategoryUpdate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var value = cm.TGetById(p.CategoryID);
            value.Name = p.Name;
            value.Description = p.Description;
            //value.Status = true;
            cm.TUpdate(value);
            return RedirectToAction("Index", "Category");
        }

    }
}
