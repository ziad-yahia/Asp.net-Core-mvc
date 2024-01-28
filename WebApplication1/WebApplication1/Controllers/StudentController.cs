using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepositry IStudentRepositry;

        public StudentController(IStudentRepositry _IStudentRepositry)
        {
            IStudentRepositry = _IStudentRepositry;
        }
        public IActionResult Index()
        {

            return View(IStudentRepositry.AllStudent());
        }

        public IActionResult Create() { 
        
            return View(IStudentRepositry);
        
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            { 
                IStudentRepositry.Create(student);  
                return RedirectToAction("Index");
            }
            return View(student);

        }

        public IActionResult Edit()
        {
           
            return View(IStudentRepositry);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                IStudentRepositry.Update(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
