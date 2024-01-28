using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        EntityDbContext context = new EntityDbContext();
        
        
        public IActionResult Index()
        {
           
            return View(context.categories.ToList());
        }

        //Get
        public IActionResult Create() { 
        
            return View();
        
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category) {

            if (category.Name == category.Displayorder.ToString())
            {
                ModelState.AddModelError("Name", "Name And DisplayOreder can Not Be The Same");
            }
            if (ModelState.IsValid)
            {
                context.categories.Add(category);
                context.SaveChanges();
                TempData["message"] = "Category Create Successfully";
                return RedirectToAction("Index");
            
            }

            return View(category);
        }



        //Get
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {

                return NotFound();
            }

            Category category=context.categories.Find(Id);

            return View(category);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {

            if (category.Name == category.Displayorder.ToString())
            {
                ModelState.AddModelError("Name", "Name And DisplayOreder can Not Be The Same");
            }
            if (ModelState.IsValid)
            {
                context.categories.Update(category);
                context.SaveChanges();
                TempData["message"] = "Category Update Successfully";
                return RedirectToAction("Index");

            }

            return View(category);
        }


        //Get
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {

                return NotFound();
            }

            Category category = context.categories.Find(Id);

            return View(category);

        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
              Category category= context.categories.FirstOrDefault(c => c.Id == Id);
                if (category == null)
                {
                     return NotFound();
                }
                context.categories.Remove(category);
                context.SaveChanges();
                TempData["message"] = "Category Delete Successfully";
                return RedirectToAction("Index");
 
        }
    }
}
