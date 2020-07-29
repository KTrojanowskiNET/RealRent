using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.ViewModels
{
    public class AddAgencyViewModel
    { 
        [Required(ErrorMessage = "To pole jest wymagane")]
    
        public int AgencyId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]

        public string Name { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]

        public string Address { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]

        [Phone]
        public string PhoneNumber { get; set; }

    }
}
