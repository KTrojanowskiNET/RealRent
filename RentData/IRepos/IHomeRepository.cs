using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.IRepos
{
    public interface IHomeRepository
    {
        public IEnumerable<Home> GetHomes();
        public Home GetHome(int id);
        public Home GetHome(string name);
        public Home AddHome(Home home);
        public void EditHome(Home home);
        public void DeleteHome(int id);
    }
}
