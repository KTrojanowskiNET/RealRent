using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentModel.Models
{
    public class Agency
    {
        public int AgencyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

    }
}
