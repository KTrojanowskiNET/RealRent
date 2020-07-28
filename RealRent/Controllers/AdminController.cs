using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealRent.Models;
using RentData.IRepos;
using RentData.Repositories;
using RentModel.Models;

namespace RealRent.Controllers
{
    [Authorize("HasAdminAccess")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<AdminController> logger;
        private readonly UserManager<AppUser> userManager;

        public AdminController(IUnitOfWork unitOfWork, ILogger<AdminController> logger, UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.userManager = userManager;
        }
        public IActionResult Properties()
        {
            List<IProperty> props = unitOfWork.GetAllProperties();

            return View(props);
        }

        public IActionResult Users()
        {
            IEnumerable<AppUser> users = userManager.Users;

            return View(users);
        }
        public IActionResult TestLog()
        {
            try
            {
            var advertisement = unitOfWork.AdvertismentRepository.GetAdvertisement(2);
            //logger.LogInformation("GetAdvertisements method test: 1.Adv.PhotoName{0}, Home{1}, Apartment{2}, Room{3}, CS{4}",
            //    advertisement.PhotoName, advertisement.Home.PhotoName, advertisement.Apartment.PhotoName, advertisement.Room.PhotoName, advertisement.CommercialSpace.PhotoName );
            }
            catch (Exception ex)
            {

                logger.LogError("Getting Advertisement from repository failed, message: {1}", ex.Message);
            }
            return Ok();
        }

        public IActionResult Edit(string name, PropertyType type)
        {
            if (type == PropertyType.Dom)
            {
                var home = unitOfWork.HomeRepository.GetHome(name);
                return RedirectToAction("Edit", "Homes", new { id = home.HomeId });
            }
            if (type == PropertyType.Mieszkanie)
            {
                var advertisement = unitOfWork.ApartmentRepository.GetApartment(name);
                return RedirectToAction("Edit", "Advertisements", new { id = advertisement.AdvertisementId });
            }
            if (type == PropertyType.Lokal_użytkowy)
            {
                var cs = unitOfWork.CommercialSpaceRepository.GetCommercialSpace(name);
                return RedirectToAction("Edit", "CommercialSpaces", new { id = cs.CommercialSpaceId });
            }
            else
            {
                var room = unitOfWork.RoomRepository.GetRoom(name);
                return RedirectToAction("Edit", "Rooms", new { id = room.RoomId });
            }
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
            return RedirectToAction("Users");
        }
        public IActionResult DeleteProperty(string name, PropertyType type)
        {
            if (type == PropertyType.Dom)
            {
                Home home = unitOfWork.HomeRepository.GetHome(name);
                if (home != null)
                {
                    unitOfWork.HomeRepository.DeleteHome(home.HomeId);
                }
            }
            if (type == PropertyType.Mieszkanie)
            {
                var apartment = unitOfWork.ApartmentRepository.GetApartment(name);
                if (apartment != null)
                {
                    unitOfWork.ApartmentRepository.DeleteApartment(apartment.ApartmentId);
                }
            }
            if (type == PropertyType.Lokal_użytkowy)
            {
                var cs = unitOfWork.CommercialSpaceRepository.GetCommercialSpace(name);
                if (cs != null)
                {
                    unitOfWork.CommercialSpaceRepository.DeleteCommercialSpace(cs.CommercialSpaceId);
                }
            }
            if (type == PropertyType.Pokój)
            {
                var room = unitOfWork.RoomRepository.GetRoom(name);
                if (room != null)
                {
                    unitOfWork.RoomRepository.DeleteRoom(room.RoomId);
                }
            }
            unitOfWork.SaveData();
            return RedirectToAction("Success", "Advertisements");
        }
    }
}
