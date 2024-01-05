using Security;

namespace NetWebApi.Model
{
    public class CreateUserDTO
    {
        public CreateUserDTO()
        {
            this.EmailConfirmed = true;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }

        public string[] Roles { get; set; }

        public User GetUser()
        {
            return new User()
            {
                Id = this.Id,
                UserName = this.UserName,
                Email = this.Email,
                PasswordHash = this.PasswordHash,
                EmailConfirmed = this.EmailConfirmed
            };
        }
    }
}