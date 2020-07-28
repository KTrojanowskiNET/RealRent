using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
    
        public CustomersController(ILogger<CustomersController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            
        }

        public IActionResult Index()
        {
            List<IProperty> props = unitOfWork.GetAllProperties();
            try
            {
                var advertisement = unitOfWork.AdvertismentRepository.GetAdvertisement(2);
                //logger.LogInformation("GetAdvertisements method test: 1.Adv.PhotoName{0}, Home{1}, Apartment{2}, Room{3}, CS{4}",
                //    advertisement.PhotoName, advertisement.Home.PhotoName, advertisement.Apartment.PhotoName, advertisement.Room.PhotoName, advertisement.CommercialSpace.PhotoName);
            }
            catch (Exception ex)
            {

                logger.LogError("Getting Advertisement from repository failed, message: {1}", ex.Message);
            }
            logger.LogInformation("Logger test InformationLevel");

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
        public IActionResult Contact()
        {
            return View();
        }

        

    }
}
