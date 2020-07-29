using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Podaj nazwę użytkownika")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Podaj adres email")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        [Required(ErrorMessage ="Podaj hasło")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Potwierdź hasło")]
        //[Display(PhotoName = "Potwierdź Hasło")]
        //[Compare("Password", ErrorMessage = "Podane hasło jest nieprawidłowe")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }

        
        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
