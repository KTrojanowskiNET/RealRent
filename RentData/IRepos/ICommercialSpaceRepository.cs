using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.IRepos
{
    public interface ICommercialSpaceRepository
    {
        public IEnumerable<CommercialSpace> GetCommercialSpaces();
        public CommercialSpace GetCommercialSpace(int id);
        public CommercialSpace GetCommercialSpace(string name);
        public CommercialSpace AddCommercialSpace(CommercialSpace space);
        public void EditCommercialSpace(CommercialSpace room);
        public void DeleteCommercialSpace(int id);
    }
}
