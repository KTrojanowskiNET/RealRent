using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace RentModel
{
    
    public class AdManager : IAdManager
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdManager(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public DateTime SetExpirationDate(int lengthInDays)
        {
            var endDate = DateTime.Now.AddDays(lengthInDays);
            return endDate;
        }

        public bool HasExpired(DateTime endDate)
        {
            if (DateTime.Now > endDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MakePayment(Advertisement advertisement)
        {
            advertisement.IsPromoted = true;
        }

        public string ReturnUniqueName(IFormFile photo)
        {
            string uniqueFileName = null;

            if (photo != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            }

            return uniqueFileName;
        }

        public void UploadPhoto(IFormFile photo, string directory, string uniqueName)
        {
            if (photo != null)
            {
                string uploadsFolder = directory;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                photo.CopyTo(fileStream);
            }
        }

    }
}
