using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        public DateTime Birthday { get; set; }

        public int ClubId { get; set; } 
        public Club Club { get; set; }
    }
}