using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentModel.Models
{
    public interface IProperty
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double SquareMetrage { get; set; }
        public double Price { get; set; }
        public int ConstructionYear { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool MainPageDisplay { get; set; }
        public bool FromAgency { get; set; }
        public string AgencyName { get; set; }
        public double? Advance { get; set; }
        public int? AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }
        public List<Photo> Images { get; set; }
        public Photo MainImage { get; set; }
        public string MainImageName { get; set; }
        public PropertyType PropertyType { get; set; }

        public string OwnerID { get; set; }

    }
}
