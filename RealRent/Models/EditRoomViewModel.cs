﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class EditRoomViewModel : AddRoomViewModel
    {
        public int Id { get; set; }
        public string MainImageName { get; set; }
    }
}
