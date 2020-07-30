using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealRent.Models;
using RealRent.ViewModels;
using RentData.IRepos;
using RentModel;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RealRent.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly ILogger<AdvertisementsController> logger;
        private readonly IUnitOfWork unit;
        private readonly UserManager<AppUser> userManager;
        private readonly IAdManager adManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IMessageService messageService;

        public AdvertisementsController(ILogger<AdvertisementsController> logger,
            IUnitOfWork unit, UserManager<AppUser> userManager, IAdManager adManager,
            IWebHostEnvironment hostingEnvironment, IMessageService messageService)
        {
            this.logger = logger;
            this.unit = unit;
            this.userManager = userManager;
            this.adManager = adManager;
            this.hostingEnvironment = hostingEnvironment;
            this.messageService = messageService;
        }

        public IActionResult List()
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult Details(PropertyType type, string name)
        {
            if (type == PropertyType.Mieszkanie)
            {
                var ap = unit.ApartmentRepository.GetApartment(name);
                return RedirectToAction("Details", "Apartments", new { id = ap.ApartmentId });
            }
            else if (type == PropertyType.Dom)
            {
                var home = unit.HomeRepository.GetHome(name);
                return RedirectToAction("Details", "Homes", new { id = home.HomeId });
            }
            else if (type == PropertyType.Lokal_użytkowy)
            {
                var cm = unit.CommercialSpaceRepository.GetCommercialSpace(name);
                return RedirectToAction("Details", "CommercialSpaces", new { id = cm.CommercialSpaceId });
            }
            else
            {
                var room = unit.RoomRepository.GetRoom(name);
                return RedirectToAction("Details", "Rooms", new { id = room.RoomId });
            }
        }
        [HttpGet]
        public IActionResult AddHome()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHome(AddHomeViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);

                Home home = new Home
                {
                    Name = model.Name,
                    NumberOfFloors = model.NumberOfFloors,
                    NumberOfRooms = model.NumberOfRooms,
                    PropertyType = PropertyType.Dom,
                    Address = model.Address,
                    Advance = model.Advance,
                    City = model.City,
                    ConstructionYear = model.ConstructionYear,
                    FullDescription = model.Description,
                    HaveFurnishings = model.HaveFurnishings,
                    HaveGarage = model.HaveGarage,
                    SquareMetrage = model.SquareMetrage,
                    TotalArea = model.TotalArea,
                    Price = model.Price,
                    MainPageDisplay = model.MainPageDisplay,
                    Images = new List<Photo>(),
                    OwnerID = user.Id

                };

                Advertisement adv = new Advertisement
                {
                    PropertyType = PropertyType.Dom,
                    DateAdded = DateTime.Now,
                    EndDate = adManager.SetExpirationDate(model.AdvLength),
                    Name = model.Name,
                    User = user,
                    Home = home
                };
                string mainName;
                if (model.MainImage != null)
                {
                    mainName = adManager.ReturnUniqueName(model.MainImage);
                    var photo = new Photo()
                    {
                        PhotoName = mainName,
                        PhotoPath = Path.Combine(Path.Combine(hostingEnvironment.WebRootPath, "images"))
                        //If using HasOne (OneToOne Relationship) instead of Owns One(OwnedType)
                        //HomePrincipal = home
                    };
                    adManager.UploadPhoto(model.MainImage, Path.Combine(hostingEnvironment.WebRootPath, "images"), mainName);
                    home.MainImageName = photo.PhotoName;
                }
                List<string> photoNames = new List<string>();
                if (model.Images != null && model.Images.Count > 0)
                {
                    var galleryPath = Path.Combine(hostingEnvironment.WebRootPath, "images", "Gallery_home_id_" + $"{model.Name}");
                    if (!Directory.Exists(galleryPath))
                    {
                        Directory.CreateDirectory(galleryPath);
                    }
                    foreach (var photo in model.Images)
                    {
                        string uniqueName = adManager.ReturnUniqueName(photo);
                        photoNames.Add(uniqueName);
                        adManager.UploadPhoto(photo, galleryPath, uniqueName);
                    }
                    foreach (var photoName in photoNames)
                    {
                        home.Images.Add(new Photo { PhotoName = photoName, PhotoPath = galleryPath /*HomesPrincipal = home*/});
                    }
                }
                adv.Home = home;
                unit.AdvertismentRepository.AddAdvertisement(adv);
                unit.SaveData();

                if (home.MainPageDisplay == true)
                {

                    return RedirectToAction("Promote", "Advertisements", new { id = adv.AdvertisementId });
                }
            }
            return RedirectToAction("Success", "Advertisements");


        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(AddRoomViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = await userManager.GetUserAsync(HttpContext.User);

                string mainName;
                string uploadDirectory = Path.Combine(hostingEnvironment.WebRootPath, "images");
                Room room = new Room
                {
                    Address = model.Address,
                    Advance = model.Advance,
                    City = model.City,
                    ConstructionYear = model.ConstructionYear,
                    FullDescription = model.Description,
                    HaveFurnishings = model.HaveFurnishings,
                    Name = model.Name,
                    Price = model.Price,
                    SquareMetrage = model.SquareMetrage,
                    TotalArea = model.TotalArea,
                    Floor = model.Floor,
                    NumberOfFlatmates = model.NumberOfFlatmates,
                    MainPageDisplay = model.MainPageDisplay,
                    Images = new List<Photo>(),
                    OwnerID = user.Id

                };
                Advertisement adv = new Advertisement
                {
                    PropertyType = PropertyType.Dom,
                    DateAdded = DateTime.Now,
                    EndDate = adManager.SetExpirationDate(model.AdvLength),
                    Name = model.Name,
                    User = user,
                    Room = room
                };
                if (model.MainImage != null)
                {
                    mainName = adManager.ReturnUniqueName(model.MainImage);
                    var photo = new Photo
                    {
                        PhotoName = mainName,
                        PhotoPath = uploadDirectory
                        //If using HasOne (OneToOne Relationship) instead of Owns One(OwnedType)
                        //RoomPrincipal = room
                    };
                    adManager.UploadPhoto(model.MainImage, uploadDirectory, mainName);
                    room.MainImageName = photo.PhotoName;
                }
                List<string> photoNames = new List<string>();
                if (model.Images != null && model.Images.Count > 0)
                {
                    var galleryPath = Path.Combine(hostingEnvironment.WebRootPath, "images", "Gallery_room_" + $"{model.Name}");
                    if (!Directory.Exists(galleryPath))
                    {
                        Directory.CreateDirectory(galleryPath);
                    }
                    foreach (var photo in model.Images)
                    {
                        string name = adManager.ReturnUniqueName(photo);
                        photoNames.Add(name);
                        adManager.UploadPhoto(photo, galleryPath, name);
                    }
                    foreach (var photoName in photoNames)
                    {
                        room.Images.Add(new Photo { PhotoName = photoName, PhotoPath = galleryPath /*RoomsPrincipal = room*/});
                    }
                }
                adv.Room = room;
                unit.AdvertismentRepository.AddAdvertisement(adv);
                unit.SaveData();
                if (model.MainPageDisplay == true)
                {
                    return RedirectToAction("Promote", "Advertisements", adv);
                }
            }
            return RedirectToAction("Success", "Advertisements");


        }

        [HttpGet]
        public IActionResult AddApartment()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddApartment(AddApartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);

                var apartment = new Apartment
                {
                    Address = model.Address,
                    Advance = model.Advance,
                    City = model.City,
                    ConstructionYear = model.ConstructionYear,
                    FullDescription = model.Description,
                    Price = model.Price,
                    SquareMetrage = model.SquareMetrage,
                    Floor = model.Floor,
                    MainPageDisplay = model.MainPageDisplay,
                    Name = model.Name,
                    NumberOfRooms = model.NumberOfRooms,
                    HaveFurnishings = model.HaveFurnishings,
                    HaveBasement = model.HaveBasement,
                    HaveBalcony = model.HaveBalcony,
                    PropertyType = PropertyType.Mieszkanie,
                    Images = new List<Photo>(),
                    OwnerID = user.Id


                };

                Advertisement adv = new Advertisement
                {
                    PropertyType = PropertyType.Dom,
                    DateAdded = DateTime.Now,
                    EndDate = adManager.SetExpirationDate(model.AdvLength),
                    Name = model.Name,
                    User = user,
                    Apartment = apartment
                };
                string mainName;
                string uploadsDirectory = Path.Combine(hostingEnvironment.WebRootPath, "images");
                if (model.MainImage != null)
                {
                    mainName = adManager.ReturnUniqueName(model.MainImage);
                    var photo = new Photo
                    {
                        PhotoName = mainName,
                        PhotoPath = uploadsDirectory
                        //If using HasOne (OneToOne Relationship) instead of Owns One(OwnedType)
                        //ApartmentPrincipal = apartment
                    };
                    adManager.UploadPhoto(model.MainImage, uploadsDirectory, mainName);
                    apartment.MainImageName = photo.PhotoName;
                }
                List<string> photoNames = new List<string>();
                if (model.Images != null && model.Images.Count > 0)
                {
                    var galleryPath = Path.Combine(hostingEnvironment.WebRootPath, "images", "Gallery_ap_" + $"{model.Name}");
                    if (!Directory.Exists(galleryPath))
                    {
                        Directory.CreateDirectory(galleryPath);
                    }
                    foreach (var photo in model.Images)
                    {
                        string name = adManager.ReturnUniqueName(photo);
                        photoNames.Add(name);
                        adManager.UploadPhoto(photo, galleryPath, name);
                    }
                    foreach (var photoName in photoNames)
                    {
                        apartment.Images.Add(new Photo { PhotoName = photoName, PhotoPath = galleryPath /*ApartmentsPrincipal =  apartment*/ });
                    }
                }
                adv.Apartment = apartment;
                unit.AdvertismentRepository.AddAdvertisement(adv);
                unit.SaveData();
                if (model.MainPageDisplay == true)
                {
                    return RedirectToAction("Promote", "Advertisements", adv);
                }
            }
            return RedirectToAction("Success", "Advertisements");

        }

        [HttpGet]
        public IActionResult AddCommercialSpace()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddCommercialSpace(AddCommercialSpaceViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);

                var cs = new CommercialSpace
                {
                    Address = model.Address,
                    Advance = model.Advance,
                    City = model.City,
                    ConstructionYear = model.ConstructionYear,
                    FullDescription = model.Description,
                    Price = model.Price,
                    SquareMetrage = model.SquareMetrage,
                    MainPageDisplay = model.MainPageDisplay,
                    Name = model.Name,
                    NumberOfRooms = model.NumberOfRooms,
                    PropertyType = PropertyType.Lokal_użytkowy,
                    LocalType = model.Type,
                    Floor = model.Floor,
                    OwnerID = user.Id,
                    Images = new List<Photo>()

                };

                Advertisement adv = new Advertisement
                {
                    PropertyType = PropertyType.Lokal_użytkowy,
                    DateAdded = DateTime.Now,
                    EndDate = adManager.SetExpirationDate(model.AdvLength),
                    Name = model.Name,
                    User = user,
                    CommercialSpace = cs
                };
                string mainName;
                string uploadsDirectory = Path.Combine(hostingEnvironment.WebRootPath, "images");
                if (model.MainImage != null)
                {
                    mainName = adManager.ReturnUniqueName(model.MainImage);
                    var photo = new Photo
                    {
                        PhotoName = mainName,
                        PhotoPath = uploadsDirectory,
                        //If using HasOne (OneToOne Relationship) instead of Owns One(OwnedType)
                        //CommercialSpacePrincipal = cs
                    };
                    adManager.UploadPhoto(model.MainImage, uploadsDirectory, mainName);
                    cs.MainImageName = photo.PhotoName;
                }
                List<string> photoNames = new List<string>();
                if (model.Images != null && model.Images.Count > 0)
                {
                    var galleryPath = Path.Combine(hostingEnvironment.WebRootPath, "images", "Gallery_cs_id_" + $"{model.Name}");
                    if (!Directory.Exists(galleryPath))
                    {
                        Directory.CreateDirectory(galleryPath);
                    }
                    foreach (var photo in model.Images)
                    {
                        string name = adManager.ReturnUniqueName(photo);
                        photoNames.Add(name);
                        adManager.UploadPhoto(photo, galleryPath, name);
                    }
                    foreach (var photoName in photoNames)
                    {
                        cs.Images.Add(new Photo { PhotoName = photoName, PhotoPath = galleryPath /*CommercialSpacesPrincipal = cs */});
                    }
                }
                adv.CommercialSpace = cs;
                unit.AdvertismentRepository.AddAdvertisement(adv);
                unit.SaveData();
                if (model.MainPageDisplay == true)
                {
                    return RedirectToAction("Promote", "Advertisements", adv);
                }
            }
            return RedirectToAction("Success", "Advertisements");

        }

        public IActionResult Edit(string name, PropertyType type)
        {
            if (type == PropertyType.Dom)
            {
                var home = unit.HomeRepository.GetHome(name);
                return RedirectToAction("Edit", "Homes", new { id = home.HomeId });
            }
            if (type == PropertyType.Mieszkanie)
            {
                var advertisement = unit.ApartmentRepository.GetApartment(name);
                return RedirectToAction("Edit", "Advertisements", new { id = advertisement.AdvertisementId });
            }
            if (type == PropertyType.Lokal_użytkowy)
            {
                var cs = unit.CommercialSpaceRepository.GetCommercialSpace(name);
                return RedirectToAction("Edit", "CommercialSpaces", new { id = cs.CommercialSpaceId });
            }
            else
            {
                var room = unit.RoomRepository.GetRoom(name);
                return RedirectToAction("Edit", "Rooms", new { id = room.RoomId });
            }
        }

        public IActionResult Delete(int id, PropertyType type)
        {
            if (type == PropertyType.Dom)
            {

                unit.AdvertismentRepository.DeleteHomeAdvertisement(id);
            }
            if (type == PropertyType.Mieszkanie)
            {
                unit.AdvertismentRepository.DeleteApartmentAdvertisement(id);
            }
            if (type == PropertyType.Lokal_użytkowy)
            {
                unit.AdvertismentRepository.DeleteCommercialSpaceAdvertisement(id);
            }
            if (type == PropertyType.Pokój)
            {
                unit.AdvertismentRepository.DeleteRoomAdvertisement(id);
            }
            unit.SaveData();
            return RedirectToAction("Success", "Advertisements");
        }


        [HttpGet]
        public IActionResult Promote(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public IActionResult PromotePost(int id)
        {
            var adv = unit.AdvertismentRepository.GetAdvertisement(id);
            adManager.MakePayment(adv);
            unit.SaveData();
            if (adv.IsPromoted == true)
            {
                return RedirectToAction("Success", "Advertisements");
            }
            else
            {
                throw new Exception("Płatność Nie powiodła się");
            }
        }


        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Question(string id)
        {
            var owner = await userManager.FindByIdAsync(id);
            var questioner = await userManager.GetUserAsync(HttpContext.User);
            var messageModel = new UserMessageViewModel
            {
                RecieverEmail = owner.Email,
                RecieverName = owner.UserName,
                SenderEmail = questioner.Email,
                SenderName = questioner.UserName,
                Subject = "Pytanie dotyczące ogłoszenia na Real-Rent",
                

            };
            return View(messageModel);

        }

        [HttpPost]
        public IActionResult Question(UserMessageViewModel messageModel)
        {
            if (messageModel != null)
            {
                var message = new UserMessage
                {
                    RecieverEmail = messageModel.RecieverEmail,
                    RecieverName = messageModel.RecieverName,
                    SenderEmail = messageModel.SenderEmail,
                    SenderName = messageModel.SenderName,
                    Text = messageModel.Text
                };
                messageService.MessageToUser(message);

            }
            return RedirectToAction("Success", "Advertisements");


        }

    }
}
