using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentModel.Models
{
    public class ServiceMessage
    {
        public string SenderName { get; set; }
        private string recieverName;
        public string RecieverName {
            get
            {
                return recieverName;
            }
            set 
            {
                recieverName = "Krystian";
            } 
        }
        public string SenderEmail { get; set; }
        private string recieverEmail;
        public string RecieverEmail {
            get
            {
                return recieverEmail;
            }
            set 
            {
                recieverEmail = "ktrojanowski.net@yahoo.com";
            } 
        }
        public string SenderPassword { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
