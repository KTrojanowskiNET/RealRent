using Microsoft.EntityFrameworkCore;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentData.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly AppDbContext dbContext;

        public ApartmentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Apartment AddApartment(Apartment apartment)
        {
            dbContext.Apartments.Add(apartment);
            return apartment;
        }

        public void DeleteApartment(int id)
        {
            var ap = dbContext.Apartments.Find(id);
            if (ap != null)
            {
                dbContext.Remove(ap);
            }
        }

        public void EditApartment(Apartment apartment)
        {
            if (apartment != null)
            {
               dbContext.Attach(apartment);
               dbContext.Entry(apartment).State = EntityState.Modified;
            }
        }

        public Apartment GetApartment(int id)
        {
            var ap = dbContext.Apartments.Find(id);
            
            
            return ap;
            
        }

      
        public Apartment GetApartment(string name)
        {
            var ap = dbContext.Apartments.FirstOrDefault(a => a.Name == name);
            return ap;

        }


        public IEnumerable<Apartment> GetApartments()
        {
            return dbContext.Apartments.AsNoTracking();
        }
    }
}
