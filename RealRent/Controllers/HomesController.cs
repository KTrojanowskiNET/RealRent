using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
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
    public class HomesController : Controller
    {
        private readonly ILogger<HomesController> logger;
        private readonly AppDbContext dbContext;
        private readonly IUnitOfWork unit;
        private readonly IAdManager manager;
        private readonly IWebHostEnvironment environment;

        public HomesController(ILogger<HomesController> logger, AppDbContext dbContext,
            IUnitOfWork unit, IAdManager manager, IWebHostEnvironment environment)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.unit = unit;
            this.manager = manager;
            this.environment = environment;
        }


        public IActionResult List()
        {
            var homes = unit.HomeRepository.GetHomes();
            if (homes == null)
            {
                return NotFound();
            }
            return View(homes);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var home = unit.HomeRepository.GetHome(id);
            ViewBag.MainPic = null;
            if (home == null)
            {
                return NotFound();
            }
            if (home.MainImageName != null && home.MainImageName != "PhotoName")

            {
                ViewBag.MainPic = Url.Content(Path.Combine("~/images/", home.MainImageName));
            }
            else
            {
                ViewBag.MainPic = Url.Content("~/images/house.jpg");
            }
            return View(home);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var home = unit.HomeRepository.GetHome(id);
            EditHomeViewModel viewModel = new EditHomeViewModel
            {
                Address = home.Address,
                Advance = home.Advance,
                City = home.City,
                ConstructionYear = home.ConstructionYear,
                Description = home.FullDescription,
                Price = home.Price,
                SquareMetrage = home.SquareMetrage,
                Name = home.Name,
                NumberOfRooms = home.NumberOfRooms,
                //MainImageName = home.MainImage.PhotoName,
                Id = home.HomeId,
                NumberOfFloors = home.NumberOfFloors,
                TotalArea = home.TotalArea,
                HaveFurnishings = home.HaveFurnishings,
                HaveGarage = home.HaveGarage
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditHomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var home = unit.HomeRepository.GetHome(model.Id);

                home.Name = model.Name;
                home.Price = model.Price;
                home.Address = model.Address;
                home.NumberOfRooms = model.NumberOfRooms;
                home.SquareMetrage = model.SquareMetrage;
                home.City = model.City;
                home.ConstructionYear = model.ConstructionYear;
                home.NumberOfFloors = model.NumberOfFloors;
                home.Advance = model.Advance;
                home.FullDescription = model.Description;
                home.TotalArea = model.TotalArea;
                home.HaveFurnishings = model.HaveFurnishings;
                home.HaveGarage = model.HaveGarage;

                if (model.MainImage != null)
                {
                    string filePath = Path.Combine(environment.WebRootPath,
                        "images", model.MainImageName);
                    System.IO.File.Delete(filePath);
                    string name = manager.ReturnUniqueName(model.MainImage);
                    manager.UploadPhoto(model.MainImage, Path.Combine(environment.WebRootPath,
                        "images"), name);
                    home.MainImage = new Photo
                    { 
                        PhotoName = name,
                        PhotoPath = Path.Combine(environment.WebRootPath, "images")
                    };
                }
                if (model.Images != null)
                {
                    List<string> photoNames = new List<string>();

                    foreach (var image in home.Images)
                    {
                        System.IO.File.Delete(image.PhotoPath);
                    }
                    foreach (var photo in model.Images)
                    {
                        var name = manager.ReturnUniqueName(photo);
                        photoNames.Add(name);
                        manager.UploadPhoto(photo, home.Images.FirstOrDefault().PhotoPath, name);
                    }
                    foreach (var photoName in photoNames)
                    {
                        home.Images.Add(new Photo { PhotoName = photoName, PhotoPath = Path.Combine(environment.WebRootPath, "images") });
                    }
                }

                unit.HomeRepository.EditHome(home);
                unit.SaveData();
                return RedirectToAction("Success", "Advertisements");

            }

            return View(model);
        }

        
    }
}
