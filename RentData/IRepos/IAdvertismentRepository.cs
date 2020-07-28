using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.IRepos
{
    public interface IAdvertismentRepository
    {
        public ICollection<Advertisement> GetAdvertisements();
        public Advertisement GetAdvertisement(int id);
        
        public ICollection<Advertisement> GetUserAdvertisements(string userName);
        public Advertisement AddAdvertisement(Advertisement advertisement);
        public void EditAdvertisement(Advertisement advertisement);
        public void DeleteHomeAdvertisement(int id);

        public void DeleteRoomAdvertisement(int id);
        public void DeleteCommercialSpaceAdvertisement(int id);
        public void DeleteApartmentAdvertisement(int id);



    }
}
