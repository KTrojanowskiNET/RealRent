using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentModel.Models
{
    public class Agency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgencyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey(nameof(Advertisement))]
        public int? AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

    }
}
