using MFF.Infrastructure;
using MFF.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
     //   private readonly IAccountService accountService;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginModel login, string checkbox)
        {
          //  var data = await accountService.Login(login);
            //    if (data != null)
            // {
            // var user = await userManager.FindByEmailAsync(login.UserName);

            //if (await userManager.CheckPasswordAsync(user, login.Password) == false)
            //{
            //    ModelState.AddModelError("message", "Invalid credentials");
            //    return View(login);

            //}

            //var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, checkbox == "on" ? true : false, true);

            //if (result.Succeeded)
            //{
            //    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
            //    return RedirectToAction("Dashboard");
            //}
            //else if (result.IsLockedOut)
            //{
            //    return View("AccountLocked");
            //}
            //else
            //{
            //    ModelState.AddModelError("message", "Invalid login attempt");
            //    return View(login);
            //}
            return RedirectToAction("Index", "Home");
        }
    }
}
