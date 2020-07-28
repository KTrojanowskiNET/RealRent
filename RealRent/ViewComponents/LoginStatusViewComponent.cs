using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Areas.Account.ViewComponents
{
    
    public class LoginStatusViewComponent : ViewComponent
    {
        //private readonly SignInManager<AppUser> _signInManager;
        //private readonly UserManager<AppUser> _userManager;

        public LoginStatusViewComponent(/*SignInManager<AppUser> signInManager, UserManager<AppUser> userManager*/)
        {
            //_signInManager = signInManager;
            //_userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
