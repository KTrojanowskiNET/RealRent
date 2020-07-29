using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class MyAccountViewModel
    {
        public AppUser CurrentUser { get; set; }
        public ICollection<Advertisement> CurrentAdvertisements { get; set; }
    }
}
