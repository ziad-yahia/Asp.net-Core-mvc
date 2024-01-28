using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        
      
        
        //DI Dependency Injection       
        IDepartmentRepositry IDepartmentRepositry;
        //IOC Inversion of control container 
        public DepartmentController(IDepartmentRepositry _IDepartmentRepositry)
        {

            IDepartmentRepositry = _IDepartmentRepositry;

        }

        [Authorize]
        public IActionResult Index()
        {
           
            //List<Department> departmentList = iTIEntities.Department.ToList();   
           var all= IDepartmentRepositry.GetAll();
            return View("Index", all);
        }

        [Authorize]
        public IActionResult Add() {

            Department department = new Department();   
            return View(department);
        
        }
        public IActionResult saveit(Department departmentmodel) {

            //if (departmentmodel.MangerName != null && departmentmodel.Name != null)
                if (ModelState.IsValid)
                {
                     //iTIEntities.Department.Add(departmentmodel);
                     //iTIEntities.SaveChanges();
                     IDepartmentRepositry.Create(departmentmodel);
                     return RedirectToAction("Index");

                }

                 return View("Add", departmentmodel);
                       
        }

        /*------------edit--------------*/
        [Authorize]
        public IActionResult Edit(int id)
        {
            //Department dep= iTIEntities.Department.FirstOrDefault(s=>s.Id == id);
            Department dep=IDepartmentRepositry.GetOne(id);
            return View(dep);
        }

        [HttpPost]
        public IActionResult SaveEdit(int Id,Department department) {

          

            //ModelState.Remove("Id");
            if (ModelState.IsValid) {

                //iTIEntities.Department.Update(department);
                //iTIEntities.SaveChanges();
                 IDepartmentRepositry.Update(Id,department);
                return RedirectToAction("Index");   
            
            }

            return View("Edit");
        }

        public IActionResult Delete(int id) {
        
            //Department department= iTIEntities.Department.FirstOrDefault(s=>s.Id ==id);
            //if (department != null) { 
            
            //    iTIEntities.Department.Remove(department);
            //    iTIEntities.SaveChanges();  
            
            //}
            IDepartmentRepositry.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
