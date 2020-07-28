using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace RentModel.Models
{
    [Owned]
    public class Photo
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }

        //public Home HomePrincipal { get; set; }
        //public Home HomesPrincipal { get; set; }
        //public CommercialSpace CommercialSpacePrincipal { get; set; }
        //public CommercialSpace CommercialSpacesPrincipal { get; set; }
        //public Apartment ApartmentPrincipal { get; set; }
        //public Apartment ApartmentsPrincipal { get; set; }
        //public Room RoomPrincipal { get; set; }
        //public Room RoomsPrincipal { get; set; }
        //[ForeignKey("HomePrincipal")]
        //public int? HomePrincipalId { get; set; }
        
        //[ForeignKey("HomesPrincipal")]
        //public int? HomesPrincipalId { get; set; }

        //[ForeignKey("CommercialSpace")]
        //public int? CommercialSpacePrincipalId { get; set; }

        //[ForeignKey("CommercialSpaces")]
        //public int? CommercialSpacesPrincipalId { get; set; }

        //[ForeignKey("Apartment")]
        //public int? ApartmentPrincipalId { get; set; }

        //[ForeignKey("Apartments")]
        //public int? ApartmentsPrincipalId { get; set; }

        //[ForeignKey("Room")]
        //public int? RoomPrincipalId { get; set; }

        //[ForeignKey("Rooms")]
        //public int? RoomsPrincipalId { get; set; }
    }
}
