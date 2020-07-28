using Microsoft.AspNetCore.Mvc;
using RealRent.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RentModel.Models;
using System.Security.Principal;
using RealRent.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RentData.IRepos;
using RentModel;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Claims;

namespace RealRent.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public AccountController(ILogger<AccountController> logger, SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword
                };
                var createUserResult = await userManager.CreateAsync(user, model.Password);
                if (createUserResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    if (model.UserName.Contains("Admin") || model.UserName.Contains("admin"))
                    {
                        var claim = new Claim("IsAdmin", model.UserName);
                        await userManager.AddClaimAsync(user, claim);
                    }
                    return RedirectToAction("Index", "Customers");
                }
                foreach (var error in createUserResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [AllowAnonymous]
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var logInResult = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,false);
                if (logInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Customers");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Próba logowania nie powiodła się");
                    
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Customers");
        }
        public async Task<IActionResult> MyAccount()
        {   
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var advs = unitOfWork.AdvertismentRepository.GetUserAdvertisements(currentUser.UserName);
            var advUser = new MyAccountViewModel
            {
                CurrentUser = currentUser,
                CurrentAdvertisements = advs
            };
            
            return View(advUser);
        }
        [HttpGet]
        public async Task<IActionResult> EditAccount(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            //var userClaims = await userManager.GetClaimsAsync(user);
            //if (user.UserClaims != null)
            //{

            //}
            var editUser = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword
            };
            return View(editUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(EditUserViewModel editModel)
        {
            var editUser = await userManager.FindByIdAsync(editModel.Id);

            if (editUser == null)
            {
                return NotFound();
            }
            else
            {
                editUser.UserName = editModel.UserName;
                editUser.FirstName = editModel.FirstName;
                editUser.LastName = editModel.LastName;
                editUser.Address = editModel.Address;
                editUser.Email = editModel.Email;
                editUser.PhoneNumber = editModel.PhoneNumber;
                editUser.Password = editModel.Password;
                editUser.ConfirmPassword = editModel.ConfirmPassword;

                var updateResult = await userManager.UpdateAsync(editUser);

                if (updateResult.Succeeded)
                {
                    return RedirectToAction("Success", "Advertisements");
                }
                else
                {
                    foreach (var error in updateResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(editModel);
            }
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel passwordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);

                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    var passwordResult = await userManager.ChangePasswordAsync(user, passwordViewModel.CurrentPassword, passwordViewModel.NewPassword);
                    if (passwordResult.Succeeded)
                    {
                        await signInManager.RefreshSignInAsync(user);
                        return RedirectToAction("Success", "Customers");
                    }
                    else
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View();
                    }
                }
            }
            return View(passwordViewModel);
        }

        
        
    }
}
