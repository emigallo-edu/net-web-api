using System.ComponentModel.DataAnnotations;

namespace CalculatorWeb.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}