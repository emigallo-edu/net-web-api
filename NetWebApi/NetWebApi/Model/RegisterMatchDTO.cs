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
        public int Id { get; set; }
        public int Matchid { get; set; }
        public int LocalClubGoals { get; set; }
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
    }
}