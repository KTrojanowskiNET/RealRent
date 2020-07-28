using Microsoft.AspNetCore.Mvc;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.ViewComponents
{
    public class AgenciesListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(/*IEnumerable<Agency> agencies*/)
        {

            return View();
        }

    }
}
