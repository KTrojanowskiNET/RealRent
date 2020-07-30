using Microsoft.AspNetCore.Razor.TagHelpers;
using RentData.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.CustomTagHelpers
{
    public class AgenciesDD : TagHelper
    {
        private readonly IUnitOfWork unit;

        public AgenciesDD(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var agencies = unit.AgencyRepository.GetAgencies();

            //output.PreElement.SetHtmlContent("<select class=\"mdb - select md - form md - outline colorful - select dropdown - info\" asp-for=\"AgencyName\">");
            //output.Content.SetHtmlContent("<option value=\"\">Brak</option>");
            //foreach (var agency in agencies)
            //{
            //    output.Content.SetHtmlContent($"<option value=\"{agency.Name}\">{agency.Name}</option>");
            //}
            //output.PostElement.SetHtmlContent("</select> <label>Agencja</label>");

            output.Content.SetHtmlContent("<div>X</ div>");
            base.Process(context, output);
        }
    }
}
