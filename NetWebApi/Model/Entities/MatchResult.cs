namespace Model.Entities
{
    public class MatchResult
    {
        public int Matchid { get; set; }
        public int LocalClubGoals { get; set; }
        public int VisitingClubGoals { get; set; }

        public Match Match { get; set; }
    }
}