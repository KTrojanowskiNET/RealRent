using Microsoft.Extensions.Logging;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentData.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        private readonly ILogger<UnitOfWork> logger;
        

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        private AdvertismentRepository advertismentRepository;
        public AdvertismentRepository AdvertismentRepository
        {
            get
            {
                if (advertismentRepository == null)
                {
                    advertismentRepository = new AdvertismentRepository(dbContext);
                }
                return advertismentRepository;
            }
        }
        private AgencyRepository agencyRepository;
        public AgencyRepository AgencyRepository
        {
            get
            {
                if (agencyRepository == null)
                {
                    agencyRepository = new AgencyRepository(dbContext);
                }
                return agencyRepository;
            }
        }

        private ApartmentRepository apartmentRepository;
        public ApartmentRepository ApartmentRepository
        {
            get
            {
                if (apartmentRepository == null)
                {
                    apartmentRepository = new ApartmentRepository(dbContext);
                }
                return apartmentRepository;
            }
        }

        private CommercialSpaceRepository commercialSpaceRepository;
        public CommercialSpaceRepository CommercialSpaceRepository
        {
            get
            {
                if (commercialSpaceRepository == null)
                {
                    commercialSpaceRepository = new CommercialSpaceRepository(dbContext);
                }
                return commercialSpaceRepository;
            }
        }

        private HomeRepository homeRepository;
        public HomeRepository HomeRepository
            {
            get
            {
                if (homeRepository == null)
                {
                    homeRepository = new HomeRepository(dbContext);
    }
                return homeRepository;
            }
        }

        private RoomRepository roomRepository;
        public RoomRepository RoomRepository
{
    get
    {
        if (roomRepository == null)
        {
                    roomRepository = new RoomRepository(dbContext);
        }
        return roomRepository;
    }
}

        public void SaveData()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
        public List<IProperty> GetAllProperties()
        {
            var promotedRooms = RoomRepository.GetRooms();
            var promotedHomes = HomeRepository.GetHomes(); ;
            var promotedFlats = ApartmentRepository.GetApartments();
            var promotedSpaces = CommercialSpaceRepository.GetCommercialSpaces();

            List<IProperty> props = new List<IProperty>();
            props.AddRange(promotedRooms.ToList());
            props.AddRange(promotedHomes.ToList());
            props.AddRange(promotedFlats.ToList());
            props.AddRange(promotedSpaces.ToList());

            return (props);
        }
    }
}
