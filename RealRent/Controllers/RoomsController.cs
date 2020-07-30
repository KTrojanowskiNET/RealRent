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
using Microsoft.AspNetCore.Authorization;

namespace RealRent.Controllers
{
    [Authorize]
        public class RoomsController : Controller
    {
        private readonly ILogger<RoomsController> logger;
        private readonly AppDbContext dbContext;
        private readonly IUnitOfWork unit;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IAdManager manager;

        public RoomsController(ILogger<RoomsController> logger, AppDbContext dbContext, IUnitOfWork unit,
            IWebHostEnvironment hostEnvironment, IAdManager manager)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.unit = unit;
            this.hostEnvironment = hostEnvironment;
            this.manager = manager;
        }

        public IActionResult List()
        {
            var rooms = unit.RoomRepository.GetRooms();
            if (rooms == null)
            {
                return NotFound();
            }
            ViewBag.Counter = rooms.Count();
            return View(rooms);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var room = unit.RoomRepository.GetRoom(id);
            ViewBag.MainPic = null;
            if (room == null)
            {
                return NotFound();
            }
            if (room.MainImageName != null && room.MainImageName != "PhotoName")
            {
                ViewBag.MainPic = Url.Content(Path.Combine("~/images/" + room.MainImageName));
            }
            else
            {
                //Zdjęcie domyślne gdy użytkownik nie poda swojego
                ViewBag.MainPic = Url.Content("~/images/rom.jpeg");
            }
            return View(room);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var room = unit.RoomRepository.GetRoom(id);

            EditRoomViewModel model = new EditRoomViewModel
            {
                Address = room.Address,
                Advance = room.Advance,
                City = room.City,
                ConstructionYear = room.ConstructionYear,
                Description = room.FullDescription,
                Price = room.Price,
                SquareMetrage = room.SquareMetrage,
                Name = room.Name,
                Floor = room.Floor,
                Id = room.RoomId,
                HaveFurnishings = room.HaveFurnishings,
                NumberOfFlatmates = room.NumberOfFlatmates,
                TotalArea = room.TotalArea,
                AgencyName = room.AgencyName,
                MainImageName = room.MainImageName
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var room = unit.RoomRepository.GetRoom(model.Id);

                room.Address = model.Address;
                room.Advance = model.Advance;
                room.City = model.City;
                room.ConstructionYear = model.ConstructionYear;
                room.FullDescription = model.Description;
                room.Price = model.Price;
                room.SquareMetrage = model.SquareMetrage;
                room.Name = model.Name;
                room.Floor = model.Floor;
                room.HaveFurnishings = model.HaveFurnishings;
                room.NumberOfFlatmates = model.NumberOfFlatmates;
                room.TotalArea = model.TotalArea;

                if (model.MainImage != null)
                {

                    System.IO.File.Delete(Path.Combine(room.MainImage.PhotoPath, room.MainImage.PhotoName));
                    string name = manager.ReturnUniqueName(model.MainImage);
                    manager.UploadPhoto(model.MainImage, Path.Combine(hostEnvironment.WebRootPath, "images"), name);
                    room.MainImage = new Photo
                    {
                        PhotoName = name,
                        PhotoPath = Path.Combine(hostEnvironment.WebRootPath, "images")
                    };
                    room.MainImageName = name;

                }

                if (model.Images != null)
                {
                    List<string> photoNames = new List<string>();

                    foreach (var image in room.Images)
                    {
                        System.IO.File.Delete(Path.Combine(image.PhotoPath, image.PhotoName));
                    }
                    foreach (var photo in model.Images)
                    {
                        var name = manager.ReturnUniqueName(photo);
                        photoNames.Add(name);
                        manager.UploadPhoto(photo, room.Images.FirstOrDefault().PhotoPath, name);
                    }
                    foreach (var photoName in photoNames)
                    {
                        room.Images.Add(new Photo { PhotoName = photoName, PhotoPath = Path.Combine(hostEnvironment.WebRootPath, "images") });
                    }
                }

                unit.RoomRepository.EditRoom(room);
                unit.SaveData();
                return RedirectToAction("Success", "Customers");


            }
            return View(model);
        }

    }
}
