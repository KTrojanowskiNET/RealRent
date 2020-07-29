using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Podaj Imię")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Podaj Nazwisko")]
        [Display(Name ="Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Podaj nazwę użytkownika")]
        [Display(Name ="Nazwa użytkownika")]
        public string UserName { get; set; }

        
        [Display(Name ="Adres")]
        [Required(ErrorMessage ="Podaj Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Podaj nr. telefonu")]
        [Display(Name = "Tel.")]
        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Podaj adres email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Utwórz hasło")]
        [Display(Name = "Hasło")]
        
        public string Password { get; set; }

        [Required(ErrorMessage = "Potwierdź hasło")]
        [Display(Name = "Potwierdź Hasło")]
        [Compare("Password", ErrorMessage ="Podane hasło jest nieprawidłowe")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Zaznacz opcję")]
        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
