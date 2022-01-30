using System;
namespace Api.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}