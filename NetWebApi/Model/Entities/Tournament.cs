namespace Model.Entities
{
    public class Tournament
    {
        public Tournament()
        {
            this.Standings = new List<Standing>();
            this.Matches = new List<Match>();
        }

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ICollection<Standing> Standings { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}