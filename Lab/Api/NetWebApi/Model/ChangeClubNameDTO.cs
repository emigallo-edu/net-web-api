using System.ComponentModel.DataAnnotations;

namespace NetWebApi.Model
{
    public class ChangeClubNameDTO
    {
        [Required]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }
    }
}