using Microsoft.AspNetCore.Mvc;
using RealRent.ViewModels;
using RentData.IRepos;
using RentData.Repositories;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Controllers
{
    public class AgenciesController : Controller
    {
        private readonly IUnitOfWork unit;

        public AgenciesController(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        [HttpGet]
        public IActionResult AgencyDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAgency()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAgency(AddAgencyViewModel agencyViewModel)
        {
            if (ModelState.IsValid)
            {
                var agency = new Agency
                {
                    Name = agencyViewModel.Name,
                    Address = agencyViewModel.Address,
                    PhoneNumber = agencyViewModel.PhoneNumber
                };

                unit.AgencyRepository.AddAgency(agency);
                unit.SaveData();
            }
            return View(agencyViewModel);

        }
    }


}
