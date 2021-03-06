﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class AddRoomViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string City { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Address { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public double SquareMetrage { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public double TotalArea { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public double Price { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MinLength(100, ErrorMessage = "Opis musi mieć przynajmniej 100 znaków")]
        public string Description { get; set; }
        public int ConstructionYear { get; set; }
        public bool MainPageDisplay { get; set; }
        public int? NumberOfFlatmates { get; set; }
        public bool HaveFurnishings { get; set; }
        public double? Advance { get; set; }
        public List<IFormFile> Images { get; set; }
        public IFormFile MainImage { get; set; }
        public string AgencyName { get; set; }

        public int AdvLength { get; set; }

    }
}
