
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentModel.Models
{
    public class Advertisement
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdvertisementId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime EndDate { get; set; }
        public Room Room { get; set; }
        public Home Home { get; set; }
        public Apartment Apartment { get; set; }
        public CommercialSpace CommercialSpace { get; set; }
        public string UserRef { get; set; }
        [ForeignKey("UserRef")]
        public AppUser User { get; set; }
        public bool IsPromoted { get; set; }
        public PropertyType PropertyType { get; set; }
        public Agency Agency { get; set; }

    }
}
