using Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace NetWebApi.Model
{
    public enum MatchResultEnum
    {
        LocalClubWon,
        VisitingClubWon,
        Draw
    }

    public class RegisterMatchDTO
    {
        [Required]
        public int StandingId { get; set; }

        [Required]
        public int Matchid { get; set; }

        [Required]
        public int LocalClubGoals { get; set; }

        [Required]
        public int VisitingClubGoals { get; set; }

        public MatchResultEnum CalculateMatchResult()
        {
            if (this.LocalClubGoals > this.VisitingClubGoals)
            {
                return MatchResultEnum.LocalClubWon;
            }

            if (this.VisitingClubGoals > this.LocalClubGoals)
            {
                return MatchResultEnum.VisitingClubWon;
            }

            return MatchResultEnum.Draw;
        }

        public MatchResult GetMatchResult()
        {
            return new MatchResult()
            {
                Matchid = this.Matchid,
                LocalClubGoals = this.LocalClubGoals,
                VisitingClubGoals = this.VisitingClubGoals
            };
        }
    }
}