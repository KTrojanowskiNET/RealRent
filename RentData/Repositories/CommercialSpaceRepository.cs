using Microsoft.EntityFrameworkCore;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentData.Repositories
{
    public class CommercialSpaceRepository : ICommercialSpaceRepository
    {
        private readonly AppDbContext dbContext;

        public CommercialSpaceRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CommercialSpace AddCommercialSpace(CommercialSpace space)
        {
            dbContext.CommercialSpaces.Add(space);
            return space;
        }

        public void DeleteCommercialSpace(int id)
        {
            var cs = dbContext.CommercialSpaces.Find(id);
            if (cs != null)
            {
                dbContext.Remove(cs);
            }
            
        }

        public void EditCommercialSpace(CommercialSpace space)
        {
            if (space != null)
            {
                dbContext.Attach(space);
                dbContext.Entry(space).State = EntityState.Modified;

            }
        }

        public CommercialSpace GetCommercialSpace(int id)
        {
            return dbContext.CommercialSpaces.Find(id);
        }
       

        public CommercialSpace GetCommercialSpace(string name)
        {
            return dbContext.CommercialSpaces.FirstOrDefault(c => c.Name == name);
        }

        public IEnumerable<CommercialSpace> GetCommercialSpaces()
        {
            return dbContext.CommercialSpaces.AsNoTracking();
        }
    }
}
