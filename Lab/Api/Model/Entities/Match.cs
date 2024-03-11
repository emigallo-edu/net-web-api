using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Match
    {
        public Match()
        {

        }

        public int Id { get; set; }
        public int TournamentId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int LocalClubId { get; set; }
        public int VisitingClubId { get; set; }

        [Required]
        public Club LocalClub { get; set; }

        [Required]
        public Club VisitingClub { get; set; }
    }
}