using EmployeesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Controllers
{
    public class EmployeeController : Controller
    {
        HRDatabaseContext Context = new HRDatabaseContext();


        public IActionResult nameexist(string EmployeeName,int id)
        {

            if (id == 0)
            {
                Employee employee = Context.Employees.FirstOrDefault(s => s.EmployeeName == EmployeeName);

                if (employee == null)
                
                    return Json(true);
                
                else
                
                    return Json(false);
                
            }
            else
            {
                Employee employee = Context.Employees.FirstOrDefault(s => s.EmployeeName == EmployeeName);
                if (employee == null)
                {
                    return Json(true);
                }
                else
                {
                    if (employee.EmployeeId == id)
                    
                        return Json(true);
                    
                    else
                        return Json(false);
                }
              

            }
        }


        /*----------------Get All Record---------*/
        public IActionResult Index()
        {
         List<Employee> employees = Context.Employees.ToList();
            return View(employees);
        }


        /*-------------Create Record------------*/

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepatmentName");
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                 Context.Employees.Add(model);
                 Context.SaveChanges();
                 return RedirectToAction("index");
            }
              return View();

        }


        /*-----------------Edit Record------------- */
        public IActionResult Edit(int id) 
        {
           
          Employee data = Context.Employees.Where(e=>e.EmployeeId == id).FirstOrDefault();
            
           return View("Create", data);
        }

        [HttpPost]
        public IActionResult Edit(Employee model) 
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepatmentName");
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                Context.Employees.Update(model);
                Context.SaveChanges();
                return RedirectToAction("index");
            }
            return View("Create",model);
        }

        /*----------------Delete Record --------------*/

        public IActionResult Delete(int id)
        {
            Employee data = Context.Employees.Where(s=>s.EmployeeId == id).FirstOrDefault();

            if (data != null)
            {
                Context.Employees.Remove(data);
                Context.SaveChanges();
                
            }

            return RedirectToAction("index");

        }

      

    }
}
