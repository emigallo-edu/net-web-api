using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Stadium
    {
        [Required]
        public string Name { get; set; }

        [Required] 
        public int Capacity { get; set; }

        [Required]
        public int ClubId { get; set; }

        public Club Club { get; set; }
    }
}