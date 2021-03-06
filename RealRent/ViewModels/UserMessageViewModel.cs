﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class UserMessageViewModel
    {
        public string SenderName { get; set; }
        public string RecieverName { get; set; }
        public string SenderEmail { get; set; }
        public string RecieverEmail { get; set; }
        public string SenderPassword { get; set; }
        public string Subject { get; set; } = "Pytanie dotyczące ogłoszenia na Real-Rent";
        public string Text { get; set; }
    }
}
