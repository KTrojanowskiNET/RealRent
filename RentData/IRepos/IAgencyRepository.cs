using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.IRepos
{
    public interface IAgencyRepository
    {
        public IEnumerable<Agency> GetAgencies();
        public Agency GetAgency(int id);
        public Agency AddAgency(Agency agency);
        public void EditAgency(Agency agency);
        public void DeleteAgency(int id);
    }
}
