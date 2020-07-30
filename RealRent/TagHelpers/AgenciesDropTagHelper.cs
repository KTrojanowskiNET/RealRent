using Microsoft.AspNetCore.Razor.TagHelpers;
using RentData.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.TagHelpers
{
    public class AgenciesDropTagHelper : TagHelper
    {
        private readonly IUnitOfWork unit;

        public AgenciesDropTagHelper(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var agencies = unit.AgencyRepository.GetAgencies();
            var content = new System.Text.StringBuilder();
            
            content.Append("<option value=\"\">Brak</option>");
            foreach (var agency in agencies)
            {
                content.Append($"<option value=\"{agency.Name}\">{agency.Name}</option>");
            }
            //Comented out becouse model binding didnt work, Property  asp-for ="AgencyName" specified in views
            //output.PreElement.SetHtmlContent("<select class=\" form-control  dropdown - info\" asp-for=\"AgencyName\">");

            output.Content.SetHtmlContent(content.ToString());
            
            //output.PostElement.SetHtmlContent("</select>");
            
            
        }
    }
}
