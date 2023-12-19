namespace Model.Entities
{
    public class Tournament
    {
        public Tournament()
        {
            this.Standing = new Standing();
            this.Matches = new List<Match>();
        }

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Standing Standing { get; set; }
        public ICollection<Match> Matches { get; set; }

        public void Add(Match match)
        {
            this.Matches.Add(match);
        }
    }
}