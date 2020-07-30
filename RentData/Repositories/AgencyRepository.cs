using Microsoft.EntityFrameworkCore;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentData.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly AppDbContext dbContext;

        public AgencyRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Agency AddAgency(Agency agency)
        {
            dbContext.Agencies.Add(agency);
            return agency;
        }

        public void DeleteAgency(int id)
        {
            var ag = dbContext.Agencies.Find(id);
            if (ag != null)
            {
            dbContext.Agencies.Remove(ag);
            }
        }

        public void EditAgency(Agency agency)
        {
            if (agency != null)
            {
                dbContext.Agencies.Attach(agency);
            }
        }

        public IEnumerable<Agency> GetAgencies()
        {
            return dbContext.Agencies.AsNoTracking().ToList();
        }

        public Agency GetAgency(int id)
        {
            return dbContext.Agencies.Find(id);
        }
        
    }
}
