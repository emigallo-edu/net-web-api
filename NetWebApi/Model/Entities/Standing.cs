namespace Model.Entities
{
    public class Standing
    {
        public Standing()
        {
        }

        public int Id { get; set; }

        public int ClubId { get; set; }
        //public int Position { get; set; }
        //public int MatchsPlayed { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Loss { get; set; }
        public int Scoring { get; set; }

        public Club Club { get; set; }
    }
}