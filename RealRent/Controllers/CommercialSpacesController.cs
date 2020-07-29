using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealRent.Models;
using RentData;
using RentData.IRepos;
using RentModel.Models;
using RentModel;

namespace RealRent.Controllers
{
    public class CommercialSpacesController : Controller
    {
        private readonly ILogger<CommercialSpacesController> logger;
        private readonly AppDbContext dbContext;
        private readonly IUnitOfWork unit;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IAdManager manager;
        public IAdManager Manager { get; }

        public CommercialSpacesController(ILogger<CommercialSpacesController> logger, AppDbContext dbContext,
            IUnitOfWork unit, IAdManager manager, IWebHostEnvironment hostingEnvironment)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.unit = unit;
            this.manager = manager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult List()
        {
            var spaces = unit.CommercialSpaceRepository.GetCommercialSpaces();
            if (spaces == null)
            {
                return NotFound();
            }
            return View(spaces);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var cs = unit.CommercialSpaceRepository.GetCommercialSpace(id);

            ViewBag.MainPic = null;
            if (cs == null)
            {
                return NotFound();
            }
            if (cs.MainImageName != null && cs.MainImageName != "PhotoName")

            {
                ViewBag.MainPic = Url.Content(Path.Combine("~/images/", cs.MainImageName));

            }
            else
            {
                ViewBag.MainPic = Url.Content("~/images/cs.jpg");
            }
            return View(cs);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cs = unit.CommercialSpaceRepository.GetCommercialSpace(id);

            EditCommercialSpaceViewModel viewModel = new EditCommercialSpaceViewModel
            {
                Address = cs.Address,
                Advance = cs.Advance,
                City = cs.City,
                ConstructionYear = cs.ConstructionYear,
                Description = cs.FullDescription,
                Price = cs.Price,
                SquareMetrage = cs.SquareMetrage,
                Name = cs.Name,
                NumberOfRooms = cs.NumberOfRooms,
                Floor = cs.Floor,
                Id = cs.CommercialSpaceId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCommercialSpaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cs = unit.CommercialSpaceRepository.GetCommercialSpace(model.Id);

                cs.Name = model.Name;
                cs.Price = model.Price;
                cs.Address = model.Address;
                cs.NumberOfRooms = model.NumberOfRooms;
                cs.SquareMetrage = model.SquareMetrage;
                cs.City = model.City;
                cs.ConstructionYear = model.ConstructionYear;
                cs.Floor = model.Floor;
                cs.Advance = model.Advance;
                cs.FullDescription = model.Description;

                if (model.MainImage != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                        "images", model.MainImageName);
                    System.IO.File.Delete(filePath);
                    string name = manager.ReturnUniqueName(model.MainImage);
                    manager.UploadPhoto(model.MainImage, Path.Combine(hostingEnvironment.WebRootPath,
                        "images"), name);
                    cs.MainImage = new Photo
                    {
                        PhotoName = name,
                        PhotoPath = Path.Combine(hostingEnvironment.WebRootPath, "images")
                    };
                }
                if (model.Images != null)
                {
                    List<string> photoNames = new List<string>();

                    foreach (var image in cs.Images)
                    {
                        System.IO.File.Delete(image.PhotoPath);
                    }
                    foreach (var photo in model.Images)
                    {
                        var name = manager.ReturnUniqueName(photo);
                        photoNames.Add(name);
                        manager.UploadPhoto(photo, cs.Images.FirstOrDefault().PhotoPath, name);

                    }
                    foreach (var photoName in photoNames)
                    {
                        cs.Images.Add(new Photo { PhotoName = photoName, PhotoPath = Path.Combine(hostingEnvironment.WebRootPath, "images") });
                    }
                }

                unit.CommercialSpaceRepository.EditCommercialSpace(cs);
                unit.SaveData();
                return RedirectToAction("Success", "Advertisements");

            }

            return View(model);
        }

        
    }
}
