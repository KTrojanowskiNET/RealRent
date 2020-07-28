using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.IRepos
{
    public interface IApartmentRepository
    {
        public IEnumerable<Apartment> GetApartments();
        public Apartment GetApartment(int id);
        public Apartment GetApartment(string name);
        public Apartment AddApartment(Apartment apartment);
        public void EditApartment(Apartment apartment);
        public void DeleteApartment(int id);
    }
}
