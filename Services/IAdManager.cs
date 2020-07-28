using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RentModel.Models;
using System;
using System.Collections.Generic;

namespace RentModel
{
    public interface IAdManager
    {
        bool HasExpired(DateTime endDate);
        DateTime SetExpirationDate(int length);
        public void MakePayment(Advertisement advertisement);
        public string ReturnUniqueName(IFormFile photo);
        void UploadPhoto(IFormFile photo, string uploadFolder, string uniqueName);
    }
}