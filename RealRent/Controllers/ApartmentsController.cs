using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealRent.Models;
using RentData;
using RentData.IRepos;
using RentModel.Models;
using RentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly ILogger<ApartmentsController> logger;
        private readonly IUnitOfWork unit;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IAdManager manager;

        public ApartmentsController(ILogger<ApartmentsController> logger, IUnitOfWork unit, IWebHostEnvironment hostingEnvironment, IAdManager manager)
        {
            this.logger = logger;
            this.unit = unit;
            this.hostingEnvironment = hostingEnvironment;
            this.manager = manager;
        }

        public IActionResult List()
        {

            var apartments = unit.ApartmentRepository.GetApartments();
            if (apartments == null)
            {
                return NotFound();
            }
            return View(apartments);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var apartment = unit.ApartmentRepository.GetApartment(id);
            ViewBag.MainPic = null;
            if (apartment == null)
            {
                return NotFound();
            }
            if (apartment.MainImageName != null && apartment.MainImageName != "PhotoName")
            {
                ViewBag.MainPic = Url.Content(Path.Combine("~/images/", apartment.MainImageName));

            }
            else
            {
                ViewBag.MainPic = Url.Content("~/images/apartment.jpeg");
            }
            return View(apartment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var apartment = unit.ApartmentRepository.GetApartment(id);
            EditApartmentViewModel model = new EditApartmentViewModel
            {
                Name = apartment.Name,
                Address = apartment.Address,
                Advance = apartment.Advance,
                City = apartment.City,
                ConstructionYear = apartment.ConstructionYear,
                Description = apartment.FullDescription,
                Price = apartment.Price,
                SquareMetrage = apartment.SquareMetrage,
                Floor = apartment.Floor,
                MainPageDisplay = apartment.MainPageDisplay,
                NumberOfRooms = apartment.NumberOfRooms,
                HaveFurnishings = apartment.HaveFurnishings,
                HaveBasement = apartment.HaveBasement,
                HaveBalcony = apartment.HaveBalcony,
                MainImageName = apartment.MainImageName,
                Id = apartment.ApartmentId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditApartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editApartment = unit.ApartmentRepository.GetApartment(model.Name);

                editApartment.Name = model.Name;
                editApartment.Address = model.Address;
                editApartment.Advance = model.Advance;
                editApartment.City = model.City;
                editApartment.ConstructionYear = model.ConstructionYear;
                editApartment.FullDescription = model.Description;
                editApartment.Price = model.Price;
                editApartment.SquareMetrage = model.SquareMetrage;
                editApartment.Floor = model.Floor;
                editApartment.MainPageDisplay = model.MainPageDisplay;
                editApartment.NumberOfRooms = model.NumberOfRooms;
                editApartment.HaveFurnishings = model.HaveFurnishings;
                editApartment.HaveBasement = model.HaveBasement;
                editApartment.HaveBalcony = model.HaveBalcony;


                if (model.MainImage != null)

                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                             "images", model.MainImageName);
                    System.IO.File.Delete(filePath);
                    string name = manager.ReturnUniqueName(model.MainImage);
                    manager.UploadPhoto(model.MainImage, Path.Combine(hostingEnvironment.WebRootPath,
                             "images"), name);
                    editApartment.MainImage = new Photo
                    {
                        PhotoName = name,
                        PhotoPath = Path.Combine(hostingEnvironment.WebRootPath, "images")
                    };
                    editApartment.MainImageName = name;
                }
                if (model.Images != null)
                {
                    List<string> photoNames = new List<string>();

                    foreach (var image in editApartment.Images)
                    {
                        System.IO.File.Delete(image.PhotoPath);
                    }
                    foreach (var photo in model.Images)
                    {
                        string name = manager.ReturnUniqueName(photo);
                        photoNames.Add(name);
                        manager.UploadPhoto(photo, editApartment.Images.FirstOrDefault().PhotoPath, name);
                    }
                    foreach (var photoName in photoNames)
                    {
                        editApartment.Images.Add(new Photo { PhotoName = photoName, PhotoPath = Path.Combine(hostingEnvironment.WebRootPath, "images") });
                    }
                }

                unit.ApartmentRepository.EditApartment(editApartment);
                unit.SaveData();
                return RedirectToAction("Success", "Advertisements");
            }
            return View(model);
        }

        public IActionResult Question()
        {

            throw new NotImplementedException();
        }
    }
}
