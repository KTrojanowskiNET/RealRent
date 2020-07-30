using Microsoft.EntityFrameworkCore;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentData.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDbContext dbContext;

        public HomeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Home AddHome(Home home)
        {
            dbContext.Homes.Add(home);
            return home;
        }

        public void DeleteHome(int id)
        {
            var hm = dbContext.Homes.Find(id);
            if (hm != null)
            {
                dbContext.Homes.Remove(hm);
            }
        }

        public void EditHome(Home home)
        {
            if (home != null)
            {
                dbContext.Attach(home);
                dbContext.Entry(home).State = EntityState.Modified;

            }
        }

        public Home GetHome(int id)
        {
            var hm = dbContext.Homes.FirstOrDefault(h => h.HomeId == id);
            return hm;
        }

        
        public Home GetHome(string name)
        {
            var hm = dbContext.Homes.FirstOrDefault(r => r.Name == name);
            return hm;
        }

        public IEnumerable<Home> GetHomes()
        {
            return dbContext.Homes.AsNoTracking().Include(h => h.MainImage);
        }
    }
}
