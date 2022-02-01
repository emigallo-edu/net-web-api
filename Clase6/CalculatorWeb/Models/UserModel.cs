using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorWeb.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public string Title { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre de usuario")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}