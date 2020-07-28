using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class EditUserViewModel : RegisterViewModel
    {
        public string Id { get; set; }  
        public Collection<string> Claims { get; set; }
    }
}
