using Microsoft.AspNetCore.Mvc;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.ViewComponents
{
    public class BasePropertiesListViewComponent : ViewComponent
    {

        public BasePropertiesListViewComponent()
        {
        }
        public IViewComponentResult Invoke(IProperty property)
        {

            if (property.PropertyType == PropertyType.Dom)
            {
                ViewBag.Pic = Url.Content("~/images/house.jpg");
                if (property.MainImageName != null && property.MainImageName != "PhotoName")
                {
                    ViewBag.Pic = Url.Content("~/images/" + property.MainImageName);
                }
            }
            else if (property.PropertyType == PropertyType.Lokal_użytkowy)
            {
                ViewBag.Pic = Url.Content("~/images/cs2.jpg");
                if (property.MainImageName != null && property.MainImageName != "PhotoName")

                {
                    ViewBag.Pic = Url.Content("~/images/" + property.MainImageName);
                }
            }
            else if (property.PropertyType == PropertyType.Mieszkanie)
            {
                ViewBag.Pic = Url.Content("~/images/ap.jpg");
                if (property.MainImageName != null && property.MainImageName != "PhotoName")

                {
                    ViewBag.Pic = Url.Content("~/images/" + property.MainImageName);
                }
            }
            else
            {
                ViewBag.Pic = Url.Content("~/images/room.jpg");
                if (property.MainImageName != null && property.MainImageName != "PhotoName")

                {
                    ViewBag.Pic = Url.Content("~/images/" + property.MainImageName);
                }
            }
            return View(property);
        }
    }
}
