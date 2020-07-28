using RentData.Repositories;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.IRepos
{
    public interface IUnitOfWork : IDisposable
    {
        AdvertismentRepository AdvertismentRepository { get; }
        AgencyRepository AgencyRepository { get; }
        ApartmentRepository ApartmentRepository { get; }
        CommercialSpaceRepository CommercialSpaceRepository { get; }
        HomeRepository HomeRepository { get; }
        RoomRepository RoomRepository { get; }

        void SaveData();
        public List<IProperty> GetAllProperties();

    }
}
