using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{ 

    [Authorize(Roles = "Admin")] 
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        public IActionResult Role()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Role(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole =new IdentityRole();
                identityRole.Name = roleViewModel.RoleName; 

             IdentityResult result=await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach (var role in result.Errors) {
                    
                         ModelState.AddModelError("", role.Description);
                    }
                   
                }
            }
            return View(roleViewModel);
        }
    }
}
