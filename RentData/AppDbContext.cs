using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using RentModel.Models;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace RentData
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //Removed amd replace with Owned Type
        //public DbSet<Photo> Photos { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<CommercialSpace> CommercialSpaces { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Agency> Agencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<AppUser>().HasMany(u => u.Advertisements).WithOne(a => a.User).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Advertisement>().HasOne(h => h.Home).WithOne(a => a.Advertisement).HasForeignKey<Home>(a => a.AdvertisementId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Advertisement>().HasOne(h => h.Apartment).WithOne(a => a.Advertisement).HasForeignKey<Apartment>(a => a.AdvertisementId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Advertisement>().HasOne(h => h.CommercialSpace).WithOne(a => a.Advertisement).HasForeignKey<CommercialSpace>(a => a.AdvertisementId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Advertisement>().HasOne(h => h.Room).WithOne(a => a.Advertisement).HasForeignKey<Room>(a => a.AdvertisementId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Advertisement>().HasOne(a => a.Agency).WithOne().HasForeignKey<Agency>(a => a.AdvertisementId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
                //Need 2 Image relationships for List and MainImage, use Inverseproperty?
                //Problem with relationships/migrations using this approach
            //modelBuilder.Entity<Home>().HasMany(h => h.Images).WithOne(i => i.HomesPrincipal).HasForeignKey(i => i.HomesPrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Apartment>().HasMany(a => a.Images).WithOne(i => i.ApartmentsPrincipal).HasForeignKey(i => i.ApartmentsPrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<CommercialSpace>().HasMany(c => c.Images).WithOne(i => i.CommercialSpacesPrincipal).HasForeignKey(i => i.CommercialSpacesPrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Room>().HasMany(r => r.Images).WithOne(i => i.RoomsPrincipal).HasForeignKey(i => i.RoomsPrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Home>().HasOne(h => h.MainImage).WithOne(i => i.HomePrincipal).HasForeignKey<Photo>(i => i.HomePrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Room>().HasOne(h => h.MainImage).WithOne(i => i.RoomPrincipal).HasForeignKey<Photo>(i => i.RoomPrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<CommercialSpace>().HasOne(h => h.MainImage).WithOne(i => i.CommercialSpacePrincipal).HasForeignKey<Photo>(i => i.CommercialSpacePrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Apartment>().HasOne(h => h.MainImage).WithOne(i => i.ApartmentPrincipal).HasForeignKey<Photo>(i => i.ApartmentPrincipalId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Home>().OwnsOne(h => h.MainImage);
            modelBuilder.Entity<Apartment>().OwnsOne(a => a.MainImage);
            modelBuilder.Entity<CommercialSpace>().OwnsOne(c => c.MainImage);
            modelBuilder.Entity<Room>().OwnsOne(r => r.MainImage);

            modelBuilder.Entity<Home>().OwnsMany(h => h.Images);
            modelBuilder.Entity<Apartment>().OwnsMany(a => a.Images);
            modelBuilder.Entity<CommercialSpace>().OwnsMany(a => a.Images);
            modelBuilder.Entity<Room>().OwnsMany(a => a.Images);


            modelBuilder.Entity<Agency>().HasData(
                new Agency
                {
                    AgencyId = 1,
                    Name = "Agency A",
                    Address = "Wrzosowa 7/99",
                    Slogan = "Slogan A",
                    PhoneNumber = "111 627 199"

                });
            modelBuilder.Entity<Agency>().HasData(
                new Agency
                {
                    AgencyId = 2,
                    Name = "Agency B",
                    Address = "Wrzosowa 7/999",
                    Slogan = "Slogan B",
                    PhoneNumber = "441 127 959"

                });
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {  
                Id = "1",
                FirstName = "Bonifacy",
                LastName = "Serpentyna",
                Address = "Młotkowa 2/7",
                PhoneNumber = "123 233 122",
                Email = "boni@gmail.com",
                UserName = "Boni",
                Password = "bonih",
                ConfirmPassword = "bonih"
            });
            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 1,
                Name = "Przytulny pokój",
                Floor = 3,
                NumberOfFlatmates = 1,
                City = "Gliwice",
                Address = "Słowackiego 2/5",
                HaveFurnishings = false,
                SquareMetrage = 12,
                ConstructionYear = 1992,
                Price = 500,
                Advance = 750,
                PropertyType = PropertyType.Pokój,
                FullDescription = "Przykładowy opis pokoju na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"
                //MainImage = new Photo
                //{
                //    PhotoId = -1,
                //    PhotoName = "SeedPhoto.jpg",
                //    PhotoPath = "./RealRent/wwwroot/images",
                //    RoomPrincipalId = 1,
                //},
                //Images = new List<Photo> { 
                //    new Photo {PhotoId = -2, PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", RoomsPrincipalId = 1 },
                //    new Photo { PhotoId = -3,PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", RoomsPrincipalId =1 } 
                //}

            },
            new Room
            {
                RoomId = 2,
                Name = "Pokój w Lublinie",
                Floor = 2,
                NumberOfFlatmates = 2,
                City = "Lublin",
                Address = "Słoneczna 1/2",
                HaveFurnishings = false,
                SquareMetrage = 16,
                ConstructionYear = 1995,
                Price = 570,
                Advance = 800,
                PropertyType = PropertyType.Pokój,
                FullDescription = "Przykładowy opis pokoju na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"

                //MainImage = new Photo { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -4, RoomPrincipalId = 2 },
                //Images = new List<Photo> {
                //    new Photo { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -5, RoomsPrincipalId = 2 },
                //    new Photo { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -6, RoomsPrincipalId = 2 }
                //}

            });

            modelBuilder.Entity<Home>().HasData(new Home
            {
                HomeId = 1,
                Name = "Dom nad jeziorem",
                NumberOfFloors = 2,
                NumberOfRooms = 6,
                Price = 2500,
                SquareMetrage = 140,
                HaveFurnishings = false,
                ConstructionYear = 2000,
                City = "Warszawa",
                TotalArea = 200,
                HaveGarage = false,
                Address = "Wiązów 3/9",
                Advance = 4000,
                PropertyType = PropertyType.Dom,
                FullDescription = "Przykładowy opis domu na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"

                //MainImage = new Photo { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -7, HomePrincipalId = 1 },
                //Images = new List<Photo> { 
                //    new Photo { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -8, HomesPrincipalId = 1 },
                //    new Photo { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -9, HomesPrincipalId = 1 }
                //}

            },
            new Home
            {
                HomeId = 2,
                Name = "Dom w centrum",
                NumberOfFloors = 1,
                NumberOfRooms = 4,
                Price = 2100,
                SquareMetrage = 90,
                HaveFurnishings = false,
                ConstructionYear = 2002,
                City = "Pacanów",
                TotalArea = 160,
                HaveGarage = false,
                Address = "Koziołka 3/9",
                Advance = 3000,
                PropertyType = PropertyType.Dom,
                FullDescription = "Przykładowy opis domu na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"

                //MainImage = new Photo { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -10, HomePrincipalId = 2 },
                //Images = new List<Photo> {
                //    new Photo { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -11, HomesPrincipalId = 2 },
                //    new Photo { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -12, HomesPrincipalId = 2 }
                //}

            });

            modelBuilder.Entity<Apartment>().HasData(new Apartment
            {
                ApartmentId = 1,
                Address = "Przemiarki 2/1",
                City = "Kraków",
                ConstructionYear = 1998,
                HaveFurnishings = false,
                Name = "Mieszkanie w centrum",
                NumberOfRooms = 3,
                Floor = 1,
                SquareMetrage = 64,
                Price = 1600,
                HaveBalcony = false,
                HaveBasement = false,
                Advance = 2500,
                PropertyType = PropertyType.Mieszkanie,
                FullDescription = "Przykładowy opis mieszkania na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"

                //MainImage = new Photo { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -13, ApartmentPrincipalId = 1 },
                //Images = new List<Photo> { 
                //    new Photo { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -14, ApartmentsPrincipalId = 1 },
                //    new Photo { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -15, ApartmentsPrincipalId = 1 }
                //}

            },
            new Apartment
            {
                ApartmentId = 2,
                Address = "Kunickiego 2/1",
                City = "Wrocław",
                ConstructionYear = 1995,
                HaveFurnishings = false,
                Name = "Mieszkanie na przedmieściu",
                NumberOfRooms = 2,
                Floor = 3,
                SquareMetrage = 54,
                Price = 1300,
                HaveBalcony = false,
                HaveBasement = false,
                Advance = 2000,
                PropertyType = PropertyType.Mieszkanie,
                FullDescription = "Przykładowy opis mieszkania na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"

                //MainImage = new Photo { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -16, ApartmentPrincipalId = 2 },
                //Images = new List<Photo> { 
                //    new Photo { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -17, ApartmentsPrincipalId = 2 },
                //    new Photo { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -18, ApartmentsPrincipalId = 2 } 
                //}

            }) ;
            modelBuilder.Entity<CommercialSpace>().HasData(new CommercialSpace
            {
                
                Name = "Biuro rachunkowe",
                Address = "Leśna 2/1",
                City = "Katowice",
                Price = 1200,
                Advance = 700,
                CommercialSpaceId = 1,
                ConstructionYear = 2002,
                SquareMetrage = 150,
                FromAgency = false,
                LocalType = LocalType.Usługi,
                PropertyType = PropertyType.Lokal_użytkowy,
                FullDescription = "Przykładowy opis lokalu użytkowego na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"

                //MainImage = new Photo { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -19, CommercialSpacePrincipalId = 1 },
                //Images = new List<Photo> { 
                //    new Photo { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -20, CommercialSpacesPrincipalId = 1 },
                //    new Photo { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -21, CommercialSpacesPrincipalId = 1 } 
                //}

            },
            new CommercialSpace
            {
                Name = "Sala konferencyjna",
                City = "Katowice",
                Address = "Zana 2/1",
                Price = 1000,
                Advance = 500,
                LocalType = LocalType.Biuro,
                CommercialSpaceId = 2,
                ConstructionYear = 2008,
                SquareMetrage = 80,
                FromAgency = false,
                PropertyType = PropertyType.Lokal_użytkowy,
                FullDescription = "Przykładowy opis lokalu użytkowego na potrzeby testowania aplikacji",
                MainImageName = "PhotoName"

                //MainImage = new Photo { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -22, CommercialSpacePrincipalId = 2 },
                //Images = new List<Photo> {
                //    new Photo { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -23, CommercialSpacesPrincipalId = 2 },
                //    new Photo { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -24, CommercialSpacesPrincipalId = 2 } 
                //}

            });
           
            //modelBuilder.Entity<Photo>().HasData(
            //new Photo
            //{  PhotoId = -1, PhotoName = "SeedPhoto.jpg", PhotoPath = "./RealRent/wwwroot/images", RoomPrincipalId = 1 },
            //new Photo 
            //{ PhotoId = -2, PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", RoomsPrincipalId = 1 },
            //new Photo 
            //{ PhotoId = -3, PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", RoomsPrincipalId = 1 },
            //new Photo 
            //{ PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -4, RoomPrincipalId = 2 },
            //new Photo 
            //{ PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -5, RoomsPrincipalId = 2 },
            //new Photo 
            //{ PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -6, RoomsPrincipalId = 2 },
            //new Photo 
            //{ PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -7, HomePrincipalId = 1 },
            //new Photo 
            //{ PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -8, HomesPrincipalId = 1 },
            //new Photo 
            //{ PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -9, HomesPrincipalId = 1 },
            //new Photo 
            //{ PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -10, HomePrincipalId = 2 },
            //new Photo 
            //{ PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -11, HomesPrincipalId = 2 },
            //new Photo 
            //{ PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -12, HomesPrincipalId = 2 },
            //new Photo
            //{ PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -13, ApartmentPrincipalId = 1 },
            //new Photo 
            //{ PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -14, ApartmentsPrincipalId = 1 },
            // new Photo 
            //{ PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -15, ApartmentsPrincipalId = 1 },
            // new Photo 
            // { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -16, ApartmentPrincipalId = 2 },
            // new Photo
            // { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -17, ApartmentsPrincipalId = 2 },
            // new Photo 
            // { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -18, ApartmentsPrincipalId = 2 },
            // new Photo 
            // { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -19, CommercialSpacePrincipalId = 1 },
            // new Photo
            // { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -20, CommercialSpacesPrincipalId = 1 },
            // new Photo 
            // { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -21, CommercialSpacesPrincipalId = 1 },
            // new Photo 
            // { PhotoName = "MainPhotoName", PhotoPath = "MainPhotoPath", PhotoId = -22, CommercialSpacePrincipalId = 2 },
            // new Photo 
            // { PhotoName = "GalleryPhoto1", PhotoPath = "GalleryPath1", PhotoId = -23, CommercialSpacesPrincipalId = 2 },
            // new Photo 
            // { PhotoName = "GalleryPhoto2", PhotoPath = "GalleryPath2", PhotoId = -24, CommercialSpacesPrincipalId = 2 }
            //);

            base.OnModelCreating(modelBuilder);
            
            
        }
    }
}
