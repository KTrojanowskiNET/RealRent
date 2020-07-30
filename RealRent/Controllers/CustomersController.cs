using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealRent.Models;
using RentData.IRepos;
using RentData.Repositories;
using RentModel.Models;
using Serilog;

namespace RealRent.Controllers
{

    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;
        private readonly IMessageService messageService;

        public IWebHostEnvironment Env { get; }

        public CustomersController(ILogger<CustomersController> logger, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMessageService messageService, IWebHostEnvironment env)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.messageService = messageService;
            Env = env;
        }

        public IActionResult Index()
        {
            List<IProperty> props = unitOfWork.GetAllProperties();
            ViewBag.Counter = props.Count();
            return View(props);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ONas()
        {
            return View();
        }
        public IActionResult Regulamin()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Contact()
        {

            var questioner = await userManager.GetUserAsync(HttpContext.User);
            var users = userManager.Users.AsEnumerable<AppUser>();
            //Send Message to Admin
            //var admin = users.Where(u => u.UserName.Contains("Admin")).SingleOrDefault();
            var messageModel = new ServiceMessageViewModel
            {
                RecieverEmail = "ktrojanowski.net@yahoo.com",
                RecieverName = "Krystian",
                SenderEmail = questioner.Email,
                SenderName = questioner.UserName,
                SenderPassword = questioner.Password
            };
            return View(messageModel);
        }

        [HttpPost]
        public IActionResult Contact(ServiceMessageViewModel model)
        {
            if (model != null)
            {
                var messageModel = new ServiceMessage
                {
                    RecieverEmail = model.RecieverEmail,
                    RecieverName = model.RecieverName,
                    SenderEmail = model.SenderEmail,
                    SenderName = model.SenderName,
                    SenderPassword = model.SenderPassword,
                    Subject = model.Subject,
                    Text = model.Text
                };
                messageService.MessageToCustomerService(messageModel);
                RedirectToAction("Success");
            }

            return View(model);

        }
        public IActionResult Success()
        {
            return View();
        }



    }
}
