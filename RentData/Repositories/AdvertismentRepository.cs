using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentData.Repositories
{
    public class AdvertismentRepository : IAdvertismentRepository
    {
        private readonly AppDbContext dbContext;
        public int Counter => dbContext.Advertisements.Count();

        public AdvertismentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public Advertisement AddAdvertisement(Advertisement advertisement)
        {
            dbContext.Add(advertisement);
            return advertisement;
        }

        public void DeleteHomeAdvertisement(int id)
        {
            var ad = dbContext.Advertisements
                                .Include(a => a.Home).ThenInclude(h => h.MainImage)
                                .Include(a => a.Home).ThenInclude(h => h.Images)
                                .FirstOrDefault(a => a.AdvertisementId.Equals(id));
            if (ad != null)
            {
                dbContext.Remove(ad);
            }
        }
        public void DeleteRoomAdvertisement(int id)
        {
            var ad = dbContext.Advertisements
                                .Include(a => a.Room).ThenInclude(r => r.MainImage)
                                .Include(a => a.Room).ThenInclude(r => r.Images)
                                .FirstOrDefault(a => a.AdvertisementId.Equals(id));

            if (ad != null)
            {
                dbContext.Remove(ad);
            }
        }
        public void DeleteCommercialSpaceAdvertisement(int id)
        {
            var ad = dbContext.Advertisements
                                .Include(a => a.CommercialSpace).ThenInclude(cs => cs.MainImage)
                                .Include(a => a.CommercialSpace).ThenInclude(cs => cs.Images)
                                .FirstOrDefault(a => a.AdvertisementId.Equals(id));

            if (ad != null)
            {
                dbContext.Remove(ad);
            }
        }
        public void DeleteApartmentAdvertisement(int id)
        {
            var ad = dbContext.Advertisements
                                .Include(a => a.Apartment).ThenInclude(ap => ap.MainImage)
                                .Include(a => a.Apartment).ThenInclude(ap => ap.Images)
                                .FirstOrDefault(a => a.AdvertisementId.Equals(id));

            if (ad != null)
            {
                dbContext.Remove(ad);
            }
        }

        public void EditAdvertisement(Advertisement advertisement)
        {
            if (advertisement != null)
            {
                dbContext.Attach(advertisement);
            }
        }

        public Advertisement GetAdvertisement(int id)
        {
            Advertisement ad = dbContext.Advertisements
                                .Include(a => a.Room)
                                .Include(a => a.Apartment)
                                .Include(a => a.CommercialSpace)
                                .Include(a => a.Home)
                                .Include(a => a.User)
                                .FirstOrDefault(a => a.AdvertisementId.Equals(id));
            if (ad == null)
            {
                
            }

              return ad;
        }

        public ICollection<Advertisement> GetAdvertisements()
        {
            var advertisements = dbContext.Advertisements
                                .Include(a => a.Room)
                                .Include(a => a.Apartment)
                                .Include(a => a.CommercialSpace)
                                .Include(a => a.Home).ToList();

            return advertisements;
        }

        public ICollection<Advertisement> GetUserAdvertisements(string userName)
        {
            var advertisements = dbContext.Advertisements
                                .Where(a => a.User.UserName == userName)
                                .ToList();
            return advertisements;
        }
               
    }
}
