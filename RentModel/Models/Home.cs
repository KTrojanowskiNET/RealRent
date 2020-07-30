using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentModel.Models
{
    public class Home : IProperty
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HomeId { get; set; }
        public int NumberOfFloors { get; set; }
        public int NumberOfRooms { get; set; }
        public double TotalArea { get; set; }
        public bool HaveFurnishings { get; set; }
        public bool HaveGarage { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double SquareMetrage { get; set; }
        public double Price { get; set; }
        public int ConstructionYear { get; set; }
        public string FullDescription { get; set; }
        private string sd;
        public string ShortDescription
        {
            get
            {
                return sd;
            }
            set
            {
                if (FullDescription.Length >= 100)
                {
                    sd = FullDescription.Substring(0, 95) + "...";
                }
                else
                {
                    sd = FullDescription;
                }
            }
        }
        public bool MainPageDisplay { get; set; }
        public bool FromAgency { get; set; }
        public string AgencyName { get; set; }

        public double? Advance { get; set; }

        [ForeignKey("Advertisement")]
        public int? AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

        //[InverseProperty("HomesPrincipal")]
        public List<Photo> Images { get; set; }

        //[InverseProperty("HomePrincipal")]
        public Photo MainImage { get; set; }
        public string MainImageName { get; set; }

        public PropertyType PropertyType { get; set; }
        public string OwnerID { get; set; }

    }
}
