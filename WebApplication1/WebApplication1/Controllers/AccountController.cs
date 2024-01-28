using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        //Registration
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Register(RegisterAccountViewModel Account)
        {
           
            if(ModelState.IsValid) 
            {
                IdentityUser User = new IdentityUser();
                User.Email = Account.Email;
                User.UserName = Account.UserName;

            IdentityResult result= await userManager.CreateAsync(User,Account.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(User,"Student");
                    await signInManager.SignInAsync(User, false);
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    foreach (var error in result.Errors) 
                    { 
                  
                        ModelState.AddModelError("",error.Description);
                    }

                    
                }
               
            } 
            return View(Account);
        }



        /*--------------------------login-----------------------*/
        public IActionResult login(string ReturnUrl="~/Department/index") {

            ViewData["redirectUrl"]=ReturnUrl;
            return View();
        
        }

        [HttpPost]
        public async  Task<IActionResult> login(LoginViewModel login, string ReturnUrl = "~/Department/index")
        {

            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(login.UserName);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, login.Password, login.isPersistent,false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                      // return RedirectToAction("index", "Department");
                    }
                    else
                        ModelState.AddModelError("","Username or password incorrect");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password Not Valid");
                }
                
            }
            return View(login);

        }


        /*-----------------logout************/

        public async Task<IActionResult> logout() { 
        
            await signInManager.SignOutAsync();
            return RedirectToAction("login","Account");
        
        }



        // ---------------------------admin-----------------


       public IActionResult AddAdmin()
        {
            return View("register");
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterAccountViewModel Account)
        { 
            if(ModelState.IsValid)
            {
                IdentityUser User = new IdentityUser();
                User.Email = Account.Email;
                User.UserName = Account.UserName;

                IdentityResult result = await userManager.CreateAsync(User, Account.Password);
                if (result.Succeeded)
                {
                    //Add Admin Roles
                    await userManager.AddToRoleAsync(User,"Admin");
                    //Create Cookie
                    await signInManager.SignInAsync(User, false);
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View("Register",Account);
        }


    }
}
